import { useContext, useEffect, useState } from "react";
import ItemsTablaTicket from "./ItemsTablaTicket";
import { DarkModeContext } from "../context/DarkModeContext";
import "./TablaTickets.css";
import pdf from "../assets/img/pdf.png";
import xls from "../assets/img/xls.png";
import { Spinner } from "react-bootstrap";
import jsPDF from "jspdf";
import "jspdf-autotable";
const TablaTickets = ({ listaMes, datos}) => {
  const [descargando, setDescargando] = useState(false);
  const [descargando2, setDescargando2] = useState(false);
  const { darkMode } = useContext(DarkModeContext);
  const listaDelMes = listaMes || [];

  const [busqueda, setBusqueda] = useState("");
  const [resultadosFiltrados, setResultadosFiltrados] = useState([]);

  const handleSearchChange = (e) => {
    setBusqueda(e.target.value);
  };

  const buscarFecha = () => {
    const busquedaLower = busqueda.toLowerCase();
    const resultados = listaDelMes.filter((item) =>
      item.fecha.toLowerCase().includes(busquedaLower)
    );
    setResultadosFiltrados(resultados);
  };

  // Función para manejar la descarga de Excel
  const manejarClicDescarga = async () => {
    // Desactivar el botón al iniciar la descarga
    setDescargando(true);
      const token = sessionStorage.getItem("token");
    const userId = localStorage.getItem("userId");
    const fechaActual = new Date();
      const año = datos?.anio || fechaActual.getFullYear();
      const mes = datos?.mes || fechaActual.getMonth() + 1;

    try {
      const respuesta = await fetch("/api/excel/excel", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Id: userId,
          token: token,
          Year: año,
          Month: mes,
          comercio: "todos",
        }),
      });

      if (!respuesta.ok) {
        throw new Error("La respuesta de la red no fue correcta");
      }

      const blob = await respuesta.blob();
      const urlDescarga = window.URL.createObjectURL(blob);
      const fechaActual = new Date();
      const fechaFormateada = fechaActual.toISOString().split("T")[0]; // Formato: 'YYYY-MM-DD'

      // Crear el enlace con el nombre de archivo deseado
      const enlace = document.createElement("a");
        enlace.href = urlDescarga; 
        enlace.setAttribute("download", `reporte_Zoco_${año}-${mes}.xlsx`); // Formato: 'zoco_YYYY-MM-DD.xlsx'
      document.body.appendChild(enlace);
      enlace.click();
      enlace.parentNode.removeChild(enlace);
      setDescargando(false);
    } catch (error) {
      console.error("Hubo un error:", error);
      setDescargando(false);
    }
  };
    const manejarClicDescargaPdf = async () => {
        setDescargando2(true);

        const token = sessionStorage.getItem("token");
        const userId = localStorage.getItem("userId");
        const fechaActual = new Date();
        const año = datos?.anio || fechaActual.getFullYear();
        const mes = datos?.mes || fechaActual.getMonth() + 1;

        try {
            const respuesta = await fetch("/api/pdf/pdf", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    token: token,
                    Id: userId,
                    Year: año,
                    Month: mes,
                    comercio: "todos",
                }),
            });

            if (!respuesta.ok) {
                throw new Error("La respuesta de la red no fue correcta");
            }
            const respuestaJson = await respuesta.json();
            
            const { datos: datosFiltrados, sumas } = respuestaJson;
        

            const doc = new jsPDF();

            const imgData = '/fondopdf.png'; // Ruta relativa a la imagen en la carpeta public

            // Función para agregar el fondo
            const agregarFondo = () => {
                doc.addImage(imgData, 'PNG', 0, 0, doc.internal.pageSize.getWidth(), doc.internal.pageSize.getHeight());
            };


            // Agregar fondo a la primera página
            agregarFondo();

            const titulo = "Detalle de Operaciones " + mes + "/" + año;

            // Obtener el ancho de la página
            const anchoPagina = doc.internal.pageSize.getWidth();

            // Obtener el ancho del título
            const anchoTitulo = doc.getStringUnitWidth(titulo) * doc.internal.getFontSize() / doc.internal.scaleFactor;

            // Calcular la posición x centrada
            const posXCentrada = (anchoPagina - anchoTitulo) / 2;

            // Agregar el título centrado en la primera página
            doc.text(titulo, posXCentrada, 10); 

            // Crear la tabla de sumas
            const tablaSumas = [
                `Bruto: $${sumas.bruto}`,
                `Costo Fin.: $${sumas.costoFinanciero}`,
                `Costo Ant: $${sumas.costoPorAnticipo}`,
                `Arancel: $${sumas.arancel}`,
                `IVA Arancel: $${sumas.ivaArancel}`,
                `Imp. Deb/Cred: $${sumas.impDebitoCredito}`,
                `Reten. IIBB: $${sumas.retencionIIBB}`,
                `Ret. Ganancia: $${sumas.retencionGanancia}`,
                `Ret. IVA: $${sumas.retencionIVA}`,
                `Total OP: $${sumas.totalOP}`
            ].map(item => [item]);

            doc.autoTable({
                body: tablaSumas,
                styles: {
                    fontSize: 8, // Reducir el tamaño de la fuente
                    cellPadding: 1, // Reducir el padding de la celda
                    overflow: 'linebreak', // Ajustar el texto para que no se salga de la celda
                    halign: 'left', // Alinear horizontalmente a la izquierda
                },
                columnStyles: {
                    0: { cellWidth: 'auto' } // Ajustar el ancho de la columna automáticamente
                },
                theme: 'plain' // Usar un tema plano para la tabla
            });

            // Definición de la cabecera de la tabla principal
            const head = [
                [
                    'TERMINAL', 'N OP', 'Fecha OP', 'Fecha Pago', 'N Cupón', 'N Tarjeta',
                    'Tarjeta', 'Cuotas', 'Bruto', 'Costo Fin.', 'Costo Ant', 'Arancel',
                    'IVA Arancel', 'Imp. Deb/Cred', 'Reten. IIBB', 'Ret. Ganancia', 'Ret. IVA', 'Total OP'
                ]
            ];

            // Configuración de la tabla principal
            doc.autoTable({
                head: head,
                body: datosFiltrados.map(item => [
                    item.terminal,
                    item.nroOperacion,
                    item.fechaOperacion,
                    item.fechaPago,
                    item.nroCupon,
                    item.nroTarjeta,
                    item.tarjeta,
                    item.cuotas,
                    item.bruto,
                    item.costoFinanciero,
                    item.costoPorAnticipo,
                    item.arancel,
                    item.ivaArancel,
                    item.impDebitoCredito,
                    item.retencionIIBB,
                    item.retencionGanancia,
                    item.retencionIVA,
                    item.totalOP
                ]),
                styles: {
                    fontSize: 6,
                    cellPadding: 1,
                    overflow: 'visible',
                    valign: 'middle',
                    halign: 'center',
                },
                columnStyles: {
                    0: { cellWidth: 'auto' }
                },
                headStyles: {
                    fillColor: [220, 220, 220],
                    textColor: [0, 0, 0],
                    fontStyle: 'bold'
                },
                didDrawPage: (data) => {
                    // Agregar fondo en cada nueva página
                    if (data.pageCount > 1) {
                        agregarFondo();
                    }
                }
            });

            // Guardar el documento PDF
            doc.save(`reporte_Zoco_${año}-${mes}.pdf`);

            setDescargando2(false);
        } catch (error) {
            console.error("Hubo un error:", error);
            setDescargando2(false);
        }
    };







    useEffect(() => {
    buscarFecha();
  }, [busqueda]);

  return (
    <section>
      <section className="container mt-3 mb-3 ">
        <div className="d-flex flex-wrap justify-content-between ">
          <div className="margin-centrado-responsive">
            <div className="my-3 d-flex">
              <h6 className="my-3 me-3 fs-18-a-16">Filtrar: </h6>
              <div className="campo-busqueda">
                <input
                  type="number"
                  value={busqueda}
                  onChange={handleSearchChange}
                  className={
                    darkMode
                      ? " form-control text-white label-buscador-dark lato-regular fs-18 border-0"
                      : "form-control label-buscador lato-regular fs-18 border-0"
                  }
                  placeholder="01-01-2024"
                />
              </div>
            </div>
          </div>
          <div className="d-flex centrado-responsive">
            <div className="">
              <button
                className={
                  descargando2
                    ? "btn-pdf-descargar-disabled centrado border-0 mx-2"
                    : "btn-pdf-descargar centrado border-0 mx-2"
                }
                disabled={descargando2}
                onClick={manejarClicDescargaPdf}
              >
                <div className="my-3">
                  <div className="text-center">
                    {descargando2 ? (
                      <div>
                        <Spinner
                          animation="border"
                          role="status"
                          variant="light"
                        ></Spinner>
                      </div>
                    ) : (
                      <img
                        className="img-fluid icono-pdf-xls mb-1"
                        src={pdf}
                        alt="PDF"
                      />
                    )}
                  </div>
                  <div className="d-flex justify-content-center align-items-center">
                    <h6 className="text-white lato-bold fs-16">
                      {descargando ? "Cargando..." : "Descargar"}
                    </h6>
                  </div>
                </div>
              </button>
            </div>

            <div className="">
              <button
                className={
                  descargando
                    ? "btn-pdf-descargar-disabled centrado border-0 mx-2"
                    : "btn-pdf-descargar centrado border-0 mx-2"
                }
                disabled={descargando}
                onClick={manejarClicDescarga}
              >
                <div className="my-3">
                  <div className="text-center">
                    {descargando ? (
                      <div>
                        <Spinner
                          animation="border"
                          role="status"
                          variant="light"
                        ></Spinner>
                      </div>
                    ) : (
                      <img
                        className="img-fluid icono-pdf-xls mb-1"
                        src={xls}
                        alt="Excel"
                      />
                    )}
                  </div>
                  <div className="d-flex justify-content-center align-items-center">
                    <h6 className="text-white lato-bold fs-16">
                      {descargando ? "Cargando..." : "Descargar"}
                    </h6>
                  </div>
                </div>
              </button>
            </div>
          </div>
        </div>
      </section>
      <div
        className={
          darkMode
            ? " container table-responsive py-5 px-5 bg-tabla-calculadora-dark my-5"
            : "container table-responsive py-5 px-5 bg-tabla-calculadora my-5"
        }
      >
        <table className="table table-borderless responsive striped hover">
          <thead className="border-0 ">
            <tr className="text-center tabla-thead">
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-tabla-izquierda border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white border-tabla-izquierda border-0 lato-regular fs-12 py-3 "
                }
                scope="col "
              >
                Fecha <br /> de pago
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3  "
                }
                scope="col"
              >
                Bruto
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3  "
                }
                scope="col"
              >
                Costo <br /> Fin.
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3 "
                }
                scope="col"
              >
                Arancel
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3  "
                }
                scope="col"
              >
                IVA <br /> Arancel
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3"
                    : "bg-dark text-white fs-12 lato-regular py-3 "
                }
                scope="col"
              >
                Imp. <br /> Deb/Cred
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3 "
                }
                scope="col"
              >
                Reten. <br /> IIBB
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3 "
                }
                scope="col"
              >
                Ret. <br /> Ganancía
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3 "
                }
                scope="col"
              >
                Ret. <br /> IVA
              </th>
              {/* <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3  '} 
                scope="col"
              >
                Ret. IVA <br /> (3%)
              </th> */}
              <th
                className="bg-verde text-white border-tabla-derecha lato-regular py-3  "
                scope="col"
              >
                TOTAL
              </th>
            </tr>
          </thead>
          <tbody className="text-center">
            {resultadosFiltrados.length > 0 ? (
              resultadosFiltrados.map((dato, id) => (
                <ItemsTablaTicket {...dato} key={id} />
              ))
            ) : (
              <tr>
                <td className="lato-bold fs-12-a-10">
                  No se encontraron resultados para esta fecha.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </section>
  );
};

export default TablaTickets;
