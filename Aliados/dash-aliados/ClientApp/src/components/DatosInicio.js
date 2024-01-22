import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";

const DatosInicio = ({ datos }) => {
  const { darkMode } = useContext(DarkModeContext);
  const { totalBrutoMes, totalNetoMes, totalNetoMañana, totalNetoHoy } = datos;

  const formatearAPeso = (valor) => {
    const valorFormateado = new Intl.NumberFormat("es-AR", {
      style: "currency",
      currency: "ARS",
    }).format(valor);
    const partes = valorFormateado.split(",");
    partes[0] = partes[0]
      .replace(/\D/g, "")
      .replace(/\B(?=(\d{3})+(?!\d))/g, ".");
    return partes.join(",");
  };

  function formatearValores(...valores) {
    return valores.map((valor) => formatearAPeso(valor));
  }

  const valoresFormateados = formatearValores(
    totalNetoHoy,
    totalNetoMañana,
    totalBrutoMes,
    totalNetoMes
  );

  return (
    <section className="container">
      <div className="row">
        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17 "> Hoy se Acredita: </h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center lato-bold border-0 fs-22">
              $ {valoresFormateados[0]}
            </div>
          </button>
        </article>
        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold  fs-17"> Mañana se Acredita</h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center  border-0 lato-bold fs-22">
              $ {valoresFormateados[1]}
            </div>
          </button>
        </article>
        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17"> Total Bruto</h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-22">
              $ {valoresFormateados[2]}
            </div>
          </button>
        </article>
        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17 "> Total Neto</h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-22">
              $ {valoresFormateados[3]}
            </div>
          </button>
        </article>
      </div>
    </section>
  );
};

export default DatosInicio;
