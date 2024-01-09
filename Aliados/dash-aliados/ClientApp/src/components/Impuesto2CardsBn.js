import React, { useContext } from "react";
import "./ImpuestosCards.css";
import { DarkModeContext } from "../context/DarkModeContext";

const Impuesto2CardsBn = () => {
    const { darkMode } = useContext(DarkModeContext);

  return (
    <div className="container">
      <div className="d-flex justify-content-between">
        <div className={darkMode ? "bg-card-impuestos-bn-dark " :"bg-card-impuestos-bn"} >
          <section>
            <article className=" padding-horizontal  d-flex flex-column justify-content-evenly container">
              <div className="text-center lato-bold fs-16-a-14">
                Costo por presentación fuera de término
              </div>
              <div className="d-flex justify-content-around flex-wrap mt-5">
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
            </article>
          </section>
        </div>
        <div className={darkMode ? "bg-card-impuestos-bn-dark " :"bg-card-impuestos-bn"}>
          <section>
            <article className=" padding-horizontal  d-flex flex-column justify-content-evenly container">
              <div className="text-center lato-bold fs-16-a-14">
                Costo por presentación fuera de término
              </div>
              <div className="d-flex justify-content-around flex-wrap mt-5">
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
            </article>
          </section>
        </div>
      </div>
    </div>
  );
};

export default Impuesto2CardsBn;
