import { useContext, useEffect, useState } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import "./ImpuestosCards.css";
import formatearValores from "../helpers/formatearAPeso";

const ImpuestosCards = ({ datosBack, DatosTasa }) => {
  const {
    totalBrutoMes,
    totaldebito,
    totalOperaciones,
    arancel,
    totalIva21Mes,
    ingresobruto,
    retencionganancia,
    retecionIva,
  } = datosBack;
  console.log(datosBack);
  const valoresFormateados = formatearValores(
    totalBrutoMes,
    totaldebito,
    arancel,
    totalIva21Mes,
    ingresobruto,
    retencionganancia,
    retecionIva
  );
  const { darkMode } = useContext(DarkModeContext);
  const [descripciones, setDescripciones] = useState([]);
  const [fechasVencimiento, setFechasVencimiento] = useState([]);
  const [tasas, setTasas] = useState([]);

  useEffect(() => {
    if (DatosTasa && DatosTasa.length > 0) {
      const descripcionesTemp = [];
      const fechasTemp = [];
      const tasasTemp = [];

      DatosTasa.forEach((dato) => {
        descripcionesTemp.push(dato.descripciontasa);
        tasasTemp.push(dato.tasa);

        // Formatear fecha
        const fecha = new Date(dato.fechavencimiento);
        const fechaFormateada =
          fecha.getDate().toString().padStart(2, "0") +
          "/" +
          (fecha.getMonth() + 1).toString().padStart(2, "0") +
          "/" +
          fecha.getFullYear().toString().substr(-2);
        fechasTemp.push(fechaFormateada);
      });

      setDescripciones(descripcionesTemp);
      setFechasVencimiento(fechasTemp);
      setTasas(tasasTemp);
    }
  }, [DatosTasa]);
  const descripcionPrimera =
    descripciones.length > 0 ? descripciones[0] : "Cargando...";
  const descripcionSegunda =
    descripciones.length > 0 ? descripciones[1] : "Cargando...";
  const tasaPrimera = tasas.length > 0 ? `${tasas[0]}%` : "Cargando...";
  const tasaSegunda = tasas.length > 0 ? `${tasas[1]}%` : "Cargando...";
  const fechaPrimera =
    fechasVencimiento.length > 0 ? fechasVencimiento[0] : "Cargando...";
  const fechaSegunda =
    fechasVencimiento.length > 0 ? fechasVencimiento[1] : "Cargando...";
  console.log(valoresFormateados);
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
                <div className="lato-bold fs-14">
                  {" "}
                  $ {valoresFormateados[0]}
                </div>
              </div>
              <div className="d-flex justify-content-between flex-wrap  mx-2">
                <div className="lato-regular fs-14">IVA Débito fiscal</div>
                <div className="lato-bold fs-14">
                  {" "}
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
                    {" "}
                    $ {valoresFormateados[2]}
                  </div>
                </div>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">IVA Débito fiscal</div>
                  <div className="lato-bold fs-14">
                    {" "}
                    $ {valoresFormateados[3]}
                  </div>
                </div>
                <div className="d-flex justify-content-between flex-wrap mx-2">
                  <div className="lato-regular fs-14">{totalOperaciones}</div>
                </div>
              </div>
            </div>
            <hr className="hr-card-impuestos" />
            <div className="text-center">
              <div className="d-flex justify-content-between flex-wrap mx-2 my-2">
                <div className="fs-16-a-14 lato-bold">Total Ret. IVA</div>
                <div className="fs-16-a-14 lato-bold">
                  ${valoresFormateados[6]}
                </div>
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
                <h6 className="lato-bold fs-14 ">{descripcionPrimera}</h6>
                <h4 className="lato-bold fs-20"> {tasaPrimera}</h4>
              </div>
              <div className="text-center">
                <h6 className="lato-bold fs-14">Fecha de Vencimiento</h6>
                <h4 className="mt-2 lato-bold fs-20"> {fechaPrimera}</h4>
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
                <div className="lato-bold fs-14">$ {valoresFormateados[4]}</div>
              </div>
            </div>
            <hr className="hr-card-impuestos" />
            <div className="text-center fs-18-a-16 lato-bold">
              Retención de ganancias
            </div>
            <div>
              <div className="d-flex justify-content-between  flex-wrap  mx-2  ">
                <div className="lato-regular fs-14">Total:</div>
                <div className="lato-bold fs-14">$ {valoresFormateados[5]}</div>
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
                <h6 className="lato-bold fs-14 ">{descripcionSegunda}</h6>
                <h4 className="lato-bold fs-20"> {tasaSegunda}</h4>
              </div>
              <div className="text-center">
                <h6 className="lato-bold fs-14">Fecha de Vencimiento</h6>
                <h4 className="mt-2 lato-bold fs-20"> {fechaSegunda}</h4>
              </div>
            </div>
          </div>
        </article>
      </div>
    </section>
  );
};

export default ImpuestosCards;
