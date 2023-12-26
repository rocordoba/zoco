import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";

const DatosInicio = ({datos }) => {
  const { darkMode } = useContext(DarkModeContext)
  const {totalBrutoMes, totalNetoMes, totalNetoMañana,totalNetoHoy} = datos;

    return (
      <section className="container">
        <div className="row">
          <article className="col-12 col-md-6 col-lg-3  py-2">
            <h6 className="text-center lato-bold fs-17 "> Hoy se Acredita: </h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'} >
              <div className=" d-flex justify-content-center lato-bold border-0 fs-24">
                $ {totalNetoHoy}
              </div>
            </button>
          </article>
          <article className="col-12 col-md-6 col-lg-3  py-2">
            <h6 className="text-center lato-bold  fs-17">
              {" "}
              Mañana se Acredita
            </h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center  border-0 lato-bold fs-24">
                $ {totalNetoMañana}
              </div>
            </button>
          </article>
          <article className="col-12 col-md-6 col-lg-3  py-2">
            <h6 className="text-center lato-bold fs-17"> Total Bruto</h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
                $ {totalBrutoMes}
              </div>
            </button>
          </article>
          <article className="col-12 col-md-6 col-lg-3  py-2">
            <h6 className="text-center lato-bold fs-17 "> Total Neto</h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
                $ {totalNetoMes}
              </div>
            </button>
          </article>
        </div>
      </section>
    );
  };
  
  export default DatosInicio;
  