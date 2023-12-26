import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";

const DatosAnalisis = () => {
  const { darkMode } = useContext(DarkModeContext);

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
            <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
              3927
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
            <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
              $ 11.542.670,46
            </div>
          </button>
        </article>
        <article className="col-12 col-md-6 col-lg-3  py-2 d-lg-none d-block">
          <h6 className="text-center lato-bold fs-17"> Total Neto </h6>
          <button
            className={
              darkMode
                ? " bg-data-dark border-0 quitar-cursor-pointer"
                : "container-light bg-data  border-0 quitar-cursor-pointer"
            }
          >
            <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
              $ 11.542.670,46
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
            <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
              $ 6.306.580,71
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
            <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
              $ 0,00
            </div>
          </button>
        </div>
      </div>
    </section>
  );
};

export default DatosAnalisis;
