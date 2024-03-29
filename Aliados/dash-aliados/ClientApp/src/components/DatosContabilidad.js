import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import formatearValores from "../helpers/formatearAPeso";

const DatosContabilidad = ({ datosBack }) => {
  const { totalBrutoMes, totalIvaMes, totalNetoMes, totalRetencionesMes } =
    datosBack;

  const valoresFormateados = formatearValores(
    totalBrutoMes,
    totalNetoMes,
    totalRetencionesMes,
    totalIvaMes
    );
  
  const { darkMode } = useContext(DarkModeContext);
  return (
    <section className="container ">
      <div className="row">
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
              $ {valoresFormateados[0]}
            </div>
          </button>
        </article>

        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17"> Total Neto</h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-22">
              $ {valoresFormateados[1]}
            </div>
          </button>
        </article>

        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17"> Total de Retenciones</h6>
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
          <h6 className="text-center lato-bold fs-17"> IVA por Comisión</h6>
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

export default DatosContabilidad;
