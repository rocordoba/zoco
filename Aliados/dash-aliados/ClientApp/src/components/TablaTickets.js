import { useContext, useState } from "react";
import ItemsTablaTicket from "./ItemsTablaTicket";
import { DarkModeContext } from "../context/DarkModeContext";
import "./TablaTickets.css";
import { useForm } from "react-hook-form";
import pdf from "../assets/img/pdf.png";
import xls from "../assets/img/xls.png";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import pdfPrueba from "../doc/prueba.pdf";

const TablaTickets = ({ listaMes }) => {
  const { darkMode } = useContext(DarkModeContext);
  const listaDelMes = listaMes || [];

  const [datosBuscador, setDatosBuscador] = useState({});
  const { register, handleSubmit, reset } = useForm();
  const onSubmit = (datos) => {
    setDatosBuscador(datos);
    reset();
  };

   // Filtrar la lista basada en los datos del buscador
   const listaFiltrada = listaDelMes.filter(dato => {
    // Aquí asumimos que quieres filtrar por una propiedad, ajusta según tus necesidades
    return dato.fecha.includes(datosBuscador.datosBuscados);
  });


  return (
    <section>
      <section className="container mt-3 mb-3 ">
        <div className="d-flex flex-wrap justify-content-between ">
          <div className="margin-centrado-responsive">
            <div className="my-3">
              <form className="d-flex" onSubmit={handleSubmit(onSubmit)}>
                <h6 className="my-3 me-2 lato-regular fs-18">Buscar:</h6>
                <input
                  className={
                    darkMode
                      ? " form-control text-white label-buscador-dark lato-regular fs-18 border-0"
                      : "form-control label-buscador lato-regular fs-18 border-0"
                  }
                  type="search"
                  aria-label="Search"
                  {...register("datosBuscados")}
                />
                <button className="btn  btn-search ms-2" type="submit">
                  <FontAwesomeIcon
                    className="text-white"
                    icon={faMagnifyingGlass}
                  />
                </button>
              </form>
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
            {listaFiltrada.map((dato, id) => (
              <ItemsTablaTicket {...dato} key={id}></ItemsTablaTicket>
            ))}
          </tbody>
        </table>
      </div>
    </section>
  );
};

export default TablaTickets;
