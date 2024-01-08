import { useContext, useEffect, useState } from "react";
import ItemsTablaTicket from "./ItemsTablaTicket";
import { DarkModeContext } from "../context/DarkModeContext";
import "./TablaTickets.css";
import pdf from "../assets/img/pdf.png";
import xls from "../assets/img/xls.png";
import pdfPrueba from "../doc/prueba.pdf";

const TablaTickets = ({ listaMes }) => {
  const { darkMode } = useContext(DarkModeContext);
  const listaDelMes = listaMes || [];

  // Estados para el término de búsqueda y los resultados filtrados
  const [busqueda, setBusqueda] = useState("");
  const [resultadosFiltrados, setResultadosFiltrados] = useState([]);

  // Manejar el cambio en el campo de búsqueda
  const handleSearchChange = (e) => {
    setBusqueda(e.target.value);
  };

  // Función para realizar la búsqueda
  const buscarFecha = () => {
    const busquedaLower = busqueda.toLowerCase();
    const resultados = listaDelMes.filter((item) =>
      item.fecha.toLowerCase().includes(busquedaLower)
    );
    setResultadosFiltrados(resultados);
  };

  // Efecto para actualizar los resultados cuando cambia el término de búsqueda
  useEffect(() => {
    buscarFecha();
  }, [busqueda]);

  return (
    <section>
      <section className="container mt-3 mb-3 ">
        <div className="d-flex flex-wrap justify-content-between ">
          <div className="margin-centrado-responsive">
            <div className="my-3">
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
            <div className="btn-pdf-descargar centrado border-0 mx-2">
              <a
                className="text-decoration-none centrado-flex"
                href={pdfPrueba}
                download="Reporte Pdf Prueba"
              >
                <div className="my-3">
                  <div>
                    <div className="text-center">
                      <img
                        className="img-fluid icono-pdf-xls mb-1"
                        src={pdf}
                        alt="pdf"
                      />
                    </div>
                  </div>
                  <div>
                    <div className="d-flex justify-content-center align-items-center">
                      <h6 className="text-white lato-bold fs-16">Descargar</h6>
                    </div>
                  </div>
                </div>
              </a>
            </div>
            <div className="btn-pdf-descargar centrado border-0 mx-2">
              <a
                className="text-decoration-none centrado-flex"
                href={pdfPrueba}
                download="Reporte Pdf Prueba"
              >
                <div className="my-3">
                  <div>
                    <div className="text-center">
                      <img
                        className="img-fluid icono-pdf-xls mb-1"
                        src={xls}
                        alt="pdf"
                      />
                    </div>
                  </div>
                  <div>
                    <div className="d-flex justify-content-center align-items-center">
                      <h6 className="text-white lato-bold fs-16">Descargar</h6>
                    </div>
                  </div>
                </div>
              </a>
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
