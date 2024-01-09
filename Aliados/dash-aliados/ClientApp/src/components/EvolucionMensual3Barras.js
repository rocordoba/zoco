import { Bar } from "react-chartjs-2";
import "./EvolucionMensual.css";
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend,
  Filler,
} from "chart.js";

import EvolucionMensualCelular from "./EvolucionMensualCelular";
import { useContext, useState } from "react";
import { DarkModeContext } from "../context/DarkModeContext";

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  BarElement,
  Title,
  Tooltip,
  Legend,
  Filler
);

const EvolucionMensual3Barras = ({ datosBack }) => {
  const { darkMode } = useContext(DarkModeContext);
  const [barraActiva, setBarraActiva] = useState(true);
  const [barraActivaInflacion, setBarraActivaInflacion] = useState(true);
  const [barraActivaOperaciones, setBarraActivaOperaciones] = useState(true);
  const tickColor = darkMode ? "#fff" : "#292B2F";
  const backgroundColor = darkMode ? "#fff" : "#292B2F";

  const { resumenUltimos7Meses } = datosBack;

  const datosResumenUltimosMeses = resumenUltimos7Meses || [];
  const totalBruto7Meses = datosResumenUltimosMeses.map(
    (dato) => dato.totalBruto
  );


  const totalOperaciones = datosResumenUltimosMeses.map(
    (dato) => dato.cantidadDatos
  );
  const ultimos7Meses = datosResumenUltimosMeses.map((dato) => dato.mes);
  const totalBrutoMenosInflacion = datosResumenUltimosMeses.map(
    (dato) => dato.totalBrutoMenosInflacion
  );

  let totalBruto = totalBruto7Meses;
  let totalBrutoInflacion = totalBrutoMenosInflacion;
  let operaciones = totalOperaciones;

  let meses = ultimos7Meses;

  var misoptions = {
    responsive: true,
    plugins: {
      legend: {
        display: false,
      },
    },
    scales: {
      y: {
        display: false,
        grid: {
          display: false,
        },
      },
      x: {
        grid: {
          display: false,
        },
        ticks: {
          color: tickColor, // Utiliza el color dinámico aquí
          font: {
            size: 18,
          },
        },
      },
    },
  };

  var midata = {
    labels: meses,
    datasets: [
      {
        label: "Por monto $",
        // data: barraActiva ? [180, 60, 40, 90, 80, 70, 70, 80, 90] : [],
        data: barraActiva ? totalBruto : [],
        backgroundColor: "#B4C400",
      },
      {
        label: "Ajuste por inflación $",
        data: barraActivaInflacion ? totalBrutoInflacion : [],
        // data: barraActivaInflacion ? totalBrutoInflacion : [],
        backgroundColor: backgroundColor,
      },
      {
        label: "Por cantidad de operaciones $",
        // data: barraActivaOperaciones ? operaciones : [],
        data: barraActivaOperaciones ? operaciones : [],
        backgroundColor: "#B3B5BF",
      },
    ],
  };

  midata.datasets.forEach(function (dataset) {
    dataset.barPercentage = 1;
    dataset.barThickness = 40;
  });

  const activadoMonto = () => {
    if (darkMode && barraActiva) {
      return "btn-activar-monto ";
    } else if (darkMode) {
      return "btn-activar-monto-activo text-white ";
    } else if (barraActiva) {
      return "btn-activar-monto ";
    } else {
      return " btn-activar-monto-activo";
    }
  };

  const activadoInflacion = () => {
    if (darkMode && barraActivaInflacion) {
      return "btn-inflacion-activado-dark";
    } else if (darkMode) {
      return " btn-inflacion-desactivado-dark text-white";
    } else if (barraActivaInflacion) {
      return "btn-activar-inflacion-activado";
    } else {
      return " btn-activar-inflacion-desactivado";
    }
  };

  const activadoOperacion = () => {
    if (darkMode && barraActivaOperaciones) {
      return "btn-operaciones-activado";
    } else if (darkMode) {
      return " btn-operaciones-desactivado-dark";
    } else if (barraActivaOperaciones) {
      return "btn-operaciones-activado";
    } else {
      return "btn-operaciones-desactivado";
    }
  };

  return (
    <div>
      <section className="container d-lg-block d-none">
        <article
          className={
            darkMode ? " bg-grafica-dark px-5 pb-4 " : "bg-grafica  px-5 pb-3 "
          }
        >
          <h2 className="fs-18 text-center pt-4 ">
            Evolución mensual <br />
          </h2>

          <h2
            className="fs-18 text-center py-2 "
            // className="fs-18 py-4 position-absolute start-50 translate-middle-x "
            // style={{ top: "20%" }}
          >
            <span className="fs-14 h5 mx-2">
              <button
                className={activadoMonto()}
                onClick={() => setBarraActiva(!barraActiva)}
              >
                {barraActiva ? "Por monto" : "Por monto"}
              </button>
            </span>

            <span className="fs-14 h5 mx-2">
              <button
                className={activadoInflacion()}
                onClick={() => setBarraActivaInflacion(!barraActivaInflacion)}
              >
                {barraActivaInflacion ? "Por inflación" : "Por inflación"}
              </button>
            </span>
            <span className="fs-14 h5 mx-2">
              <button
                className={activadoOperacion()}
                onClick={() =>
                  setBarraActivaOperaciones(!barraActivaOperaciones)
                }
              >
                {barraActivaOperaciones ? "Por operaciones" : "Por operaciones"}
              </button>
            </span>
          </h2>

          <Bar
            className="padding-top-grafica-analisis d-block"
            data={midata}
            options={misoptions}
          />
        </article>
      </section>
      <section className="container my-4 d-block d-lg-none">
        <EvolucionMensualCelular datosBack={datosBack} />
      </section>
    </div>
  );
};

export default EvolucionMensual3Barras;
