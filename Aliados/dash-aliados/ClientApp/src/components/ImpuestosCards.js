import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import "./ImpuestosCards.css";

const ImpuestosCards = () => {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <section className="container">
      <div className="row">
        <article className="mi-carta responsive-margin-top-3">
          <div
            className={
              darkMode
                ? " card-dark bg-card-impuesto-dark  padding-horizontal d-flex flex-column justify-content-evenly container "
                : "card bg-card-impuesto  padding-horizontal  d-flex flex-column justify-content-evenly container"
            }
          >
            <div className="text-center mt-2 fs-18-a-16 lato-bold">IVA</div>
            <div>
              <h6 className="text-center fs-16-a-14 lato-regular pb-2">
                {" "}
                IVA Ventas
              </h6>
              <div className="d-flex justify-content-between flex-wrap mx-2">
                <div className="lato-regular fs-14">Base imponible</div>
                <div className="lato-bold fs-14">$ 19.379.112,49</div>
              </div>
              <div className="d-flex justify-content-between flex-wrap  mx-2">
                <div className="lato-regular fs-14">IVA Débito fiscal</div>
                <div className="lato-bold fs-14">$ 4.069.613,62</div>
              </div>
              <div className="d-flex justify-content-between  flex-wrap  mx-2  ">
                <div className="lato-regular fs-14">Total ventas</div>
                <div className="lato-bold fs-14">3927</div>
              </div>
            </div>
            <hr className="hr-card-impuestos" />
            <div className="text-center">
              <div>
                <h6 className="text-center fs-16-a-14 lato-regular pb-2">
                  IVA Compras
                </h6>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">Base imponible</div>
                  <div className="lato-bold fs-14">$ 19.379.112,49</div>
                </div>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">IVA Débito fiscal</div>
                  <div className="lato-bold fs-14">$ 4.069.613,62</div>
                </div>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">Total ventas</div>
                  <div className="lato-bold fs-14">3927</div>
                </div>
              </div>
            </div>
            <hr className="hr-card-impuestos" />
            <div className="text-center">
              <div className="d-flex justify-content-between flex-wrap mx-2 my-2">
                <div className="fs-16-a-14 lato-bold">Total ventas</div>
                <div className="fs-16-a-14 lato-bold">$ 12.677,49</div>
              </div>
            </div>
          </div>

          <div
            className={
              darkMode
                ? " card-dark bg-card-costo-dark my-3 d-flex flex-column bd-highlight   container "
                : "card bg-card-costo my-3 d-flex flex-column bd-highlight   container"
            }
          >
            <div className="text-center lato-bold fs-16-a-14">
              Costo por presentación fuera de término
            </div>
            <div className="d-flex justify-content-around flex-wrap mt-3">
              <div className="text-center ">
                <h6 className="lato-bold fs-14 ">
                  Tasa de Interés por mes <br /> (0,12%)
                </h6>
                <h4 className="lato-bold fs-20">3,6%</h4>
              </div>
              <div className="text-center">
                <h6 className="lato-bold fs-14">Fecha de Vencimiento</h6>
                <h4 className="mt-2 lato-bold fs-20">14/08/23</h4>
              </div>
            </div>
          </div>
        </article>
        <article className="mi-carta responsive-margin-top-3">
          <div
            className={
              darkMode
                ? " card-dark bg-card-impuesto-dark  padding-horizontal d-flex flex-column justify-content-evenly container "
                : "card bg-card-impuesto  padding-horizontal  d-flex flex-column justify-content-evenly container"
            }
          >
            <div className="text-center fs-18-a-16 lato-bold">IIBB</div>
            <div>
              <div className="d-flex justify-content-between  flex-wrap  mx-2  ">
                <div className="lato-regular fs-14">Total:</div>
                <div className="lato-bold fs-14">$ 19.379.112,49</div>
              </div>
            </div>
            <hr className="hr-card-impuestos" />
            <div className="text-center fs-18-a-16 lato-bold">Retención de ganancias</div>
            <div>
              <div className="d-flex justify-content-between  flex-wrap  mx-2  ">
                <div className="lato-regular fs-14">Total:</div>
                <div className="lato-bold fs-14">$ 19.379.112,49</div>
              </div>
            </div>
           
          </div>

          <div
            className={
              darkMode
                ? " card-dark bg-card-costo-dark my-3 d-flex flex-column bd-highlight   container "
                : "card bg-card-costo my-3 d-flex flex-column bd-highlight   container"
            }
          >
            <div className="text-center lato-bold fs-16-a-14">
              Costo por presentación fuera de término
            </div>
            <div className="d-flex justify-content-around flex-wrap mt-3">
              <div className="text-center ">
                <h6 className="lato-bold fs-14 ">
                  Tasa de Interés por mes <br /> (0,12%)
                </h6>
                <h4 className="lato-bold fs-20">3,6%</h4>
              </div>
              <div className="text-center">
                <h6 className="lato-bold fs-14">Fecha de Vencimiento</h6>
                <h4 className="mt-2 lato-bold fs-20">14/08/23</h4>
              </div>
            </div>
          </div>
        </article>

      </div>
    </section>
  );
};

export default ImpuestosCards;
