import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import formatearValores from "../helpers/formatearAPeso";

const DatosAnalisis = ({ datosBack }) => {
  const { darkMode } = useContext(DarkModeContext);
  const {
    totalOperaciones,
    totalConDescuentoCuotas0,
    totalConDescuentoCuotas1,
    totalConDescuentoCuotas2

  } = datosBack;

  const valoresFormateados = formatearValores(
    totalConDescuentoCuotas0,
    totalConDescuentoCuotas1,
    totalConDescuentoCuotas2

  );
  return (
    <section className="container">
      <div className="row">
        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17">
            {" "}
            Cantidad de Operaciones
          </h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0  quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-22">
              {totalOperaciones}
            </div>
          </button>
        </article>
        <article className="col-12 col-md-6 col-lg-3  py-2 d-none d-lg-block">
          <h6 className="text-center lato-bold fs-17"> Débito</h6>
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
        <article className="col-12 col-md-6 col-lg-3  py-2 d-lg-none d-block">
          <h6 className="text-center lato-bold fs-17"> Debito </h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-22">
              ${valoresFormateados[0]}
            </div>
          </button>
        </article>

        <article className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17"> 1 Pago</h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-22">
              $ {valoresFormateados[1] }
            </div>
          </button>
        </article>
        <div className="col-12 col-md-6 col-lg-3  py-2">
          <h6 className="text-center lato-bold fs-17"> Cuotas</h6>
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
        </div>
      </div>
    </section>
  );
};

export default DatosAnalisis;
