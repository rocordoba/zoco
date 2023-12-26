import { useForm } from "react-hook-form";
import pdf from "../assets/img/pdf.png";
import xls from "../assets/img/xls.png";
import { useContext, useState } from "react";
import { faMagnifyingGlass } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import pdfPrueba from "../doc/prueba.pdf";
import { DarkModeContext } from "../context/DarkModeContext";

const Buscador = () => {
  const [datosBuscador, setDatosBuscador] = useState({});
  console.log(
    "🚀 ~ file: Buscador.js:8 ~ Buscador ~ datosBuscado:",
    datosBuscador
  );

  const { register, handleSubmit, reset } = useForm();

  const onSubmit = (datos) => {
    setDatosBuscador(datos);
    reset();
  };
  const { darkMode } = useContext(DarkModeContext);
  return (
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
  );
};

export default Buscador;
