import { useContext, useEffect, useState } from "react";
import ItemsTablaTicket from "./ItemsTablaTicket";
import { DarkModeContext } from "../context/DarkModeContext";
import "./TablaTickets.css";
import pdf from "../assets/img/pdf.png";
import xls from "../assets/img/xls.png";
import { Spinner } from "react-bootstrap";

const TablaTickets = ({ listaMes }) => {
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
    const token = localStorage.getItem("token");
    const userId = localStorage.getItem("userId");
    const fechaActual = new Date();
    const año = fechaActual.getFullYear();
    const mes = fechaActual.getMonth() + 1;

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
      enlace.setAttribute("download", `zoco_${fechaFormateada}.xlsx`); // Formato: 'zoco_YYYY-MM-DD.xlsx'
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
    const token = localStorage.getItem("token");
    const userId = localStorage.getItem("userId");
    const fechaActual = new Date();
    const año = fechaActual.getFullYear();
    const mes = fechaActual.getMonth() + 1;
    const comercio = "todos"; // O cualquier valor que necesites

    try {
      const respuesta = await fetch("/api/pdf/pdf", {
        method: "POST",
        headers: {
          "Content-Type": "application/json", // Si tu API requiere un token de autenticación
        },
        body: JSON.stringify({
          token: token,
          Id: userId,
          Year: año,
          Month: mes,
          comercio: comercio,
        }),
      });

      if (!respuesta.ok) {
        throw new Error("La respuesta de la red no fue correcta");
      }

      const blob = await respuesta.blob();
      const urlDescarga = window.URL.createObjectURL(blob);
      const enlace = document.createElement("a");
      enlace.href = urlDescarga;
      enlace.setAttribute("download", `reporte_${año}-${mes}.pdf`);
      document.body.appendChild(enlace);
      enlace.click();
      enlace.parentNode.removeChild(enlace);
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
