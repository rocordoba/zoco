import React, { useContext } from "react";
import "./ImpuestosCards.css";
import { DarkModeContext } from "../context/DarkModeContext";

const Impuesto2Cards = () => {
  const { darkMode } = useContext(DarkModeContext);

  return (
    <div className="container">
      <div className="d-flex justify-content-between">
        <div className={darkMode ? "bg-card-impuestos-dark " :"bg-card-impuestos"}>
          <section>
            <article className="contenido-card-width padding-horizontal  d-flex flex-column justify-content-evenly container">
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
            </article>
          </section>
        </div>
        <div className={darkMode ? "bg-card-impuestos-dark " :"bg-card-impuestos"}>
          <section>
            <article className="contenido-card-width padding-horizontal  d-flex flex-column justify-content-evenly container">
              <div className="text-center mt-2 fs-18-a-16 lato-bold">IIBB</div>
              <div>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">Total:</div>
                  <div className="lato-bold fs-14">$ 19.379.112,49</div>
                </div>
              </div>
              <hr className="hr-card-impuestos" />
              <div className="text-center">
                <div className="text-center mb-5 fs-18-a-16 lato-bold">
                  Retención de ganancias
                </div>
                <div>
                  <div className="d-flex justify-content-between flex-wrap mx-2">
                    <div className="lato-regular fs-14">Total:</div>
                    <div className="lato-bold fs-14">$ 19.379.112,49</div>
                  </div>
                </div>
              </div>
            </article>
          </section>
        </div>
      </div>
    </div>
  );
};

export default Impuesto2Cards;
