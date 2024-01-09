import React, { useContext } from "react";
import "./ImpuestosCards.css";
import { DarkModeContext } from "../context/DarkModeContext";
import formatearValores from "../helpers/formatearAPeso";

const Impuesto2Cards = ({ datosBack }) => {
  console.log("🚀 ~ Impuesto2Cards ~ datosBack :", datosBack);
  const { darkMode } = useContext(DarkModeContext);

  const {
    totalBrutoMes,
    totaldebito,
    totalOperaciones,
    arancel,
    totalIva21Mes,
    ingresobruto,
    retencionganancia,
  } = datosBack;

  const valoresFormateados = formatearValores(
    totalBrutoMes,
    totaldebito,
    arancel,
    totalIva21Mes,
    ingresobruto,
    retencionganancia
  );

  return (
    <div className="container">
      <div className="d-flex justify-content-between">
        <div
          className={darkMode ? "bg-card-impuestos-dark " : "bg-card-impuestos"}
        >
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
                  <div className="lato-bold fs-14">
                    $ {valoresFormateados[0]}
                  </div>
                </div>
                <div className="d-flex justify-content-between flex-wrap  mx-2">
                  <div className="lato-regular fs-14">IVA Débito fiscal</div>
                  <div className="lato-bold fs-14">
                    $ {valoresFormateados[1]}
                  </div>
                </div>
                <div className="d-flex justify-content-between  flex-wrap  mx-2  ">
                  <div className="lato-regular fs-14">Total ventas</div>
                  <div className="lato-bold fs-14">{totalOperaciones}</div>
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
                    <div className="lato-bold fs-14">
                      $ {valoresFormateados[2]}
                    </div>
                  </div>
                  <div className="d-flex justify-content-between flex-wrap mx-2">
                    <div className="lato-regular fs-14">IVA Crédito fiscal</div>
                    <div className="lato-bold fs-14">
                      $ {valoresFormateados[3]}
                    </div>
                  </div>
                  <div className="d-flex justify-content-between flex-wrap mx-2">
                    <div className="lato-regular fs-14">Total ventas</div>
                    <div className="lato-bold fs-14">{totalOperaciones}</div>
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
        <div
          className={darkMode ? "bg-card-impuestos-dark " : "bg-card-impuestos"}
        >
          <section>
            <article className="contenido-card-width padding-horizontal  d-flex flex-column justify-content-evenly container">
              <div className="text-center mt-2 fs-18-a-16 lato-bold">IIBB</div>
              <div>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">Total:</div>
                  <div className="lato-bold fs-14">
                    $ {valoresFormateados[4]}
                  </div>
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
                    <div className="lato-bold fs-14">
                      $ {valoresFormateados[5]}
                    </div>
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
