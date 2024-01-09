import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import { formatearAPeso } from "../helpers/formatearAPeso";

const DatosTickets = ({ datosCuponesContext}) => {
  const { darkMode } = useContext(DarkModeContext)
  const {totalOperaciones,totalBrutoHoy, contracargo, retenciones } = datosCuponesContext;

  const totalBrutoHoyFormateado = formatearAPeso(totalBrutoHoy);
    return (
      <section className="container">
        <div className="row">
          <article className="col-12 col-md-6 col-lg-3  py-2">
            <h6 className="text-center lato-bold  fs-17">
              {" "}
              Cantidad de Operaciones
            </h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
                {totalOperaciones}
              </div>
            </button>
          </article>
  
          <article className="col-12 col-md-6 col-lg-3 py-2">
            <h6 className="text-center lato-bold  fs-17">
              {" "}
              Acumulado del Mes
            </h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
                $ {totalBrutoHoyFormateado}
              </div>
            </button>
          </article>
  
          <article className="col-12 col-md-6 col-lg-3 py-2">
            <h6 className="text-center lato-bold  fs-17">
              {" "}
              Contracargos del Mes
            </h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
                $ {contracargo}
              </div>
            </button>
          </article>
          <article className="col-12 col-md-6 col-lg-3 py-2">
            <h6 className="text-center lato-bold  fs-17">
              {" "}
              Retenciones más Impuestos
            </h6>
            <button className={darkMode ? ' bg-data-dark border-0 quitar-cursor-pointer' : 'container-light bg-data  border-0 quitar-cursor-pointer'}>
              <div className=" d-flex justify-content-center border-0 lato-bold fs-24">
                $ {retenciones}
              </div>
            </button>
          </article>
        </div>
      </section>
    );
  };
  
  export default DatosTickets;
  