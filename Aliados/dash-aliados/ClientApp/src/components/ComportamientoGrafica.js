import { useContext, useEffect, useState } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import "./ComportamientoGrafica.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
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
import { faCircleUp } from "@fortawesome/free-solid-svg-icons";
import { Bar, Line } from "react-chartjs-2";

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

const ComportamientoGrafica = ({datos}) => {
  const { darkMode } = useContext(DarkModeContext);
  const tickColor = darkMode ? "#fff" : "#292B2F";

  const {comparativahoy, comparativaHoymesanterior, totalesPorDiaTarjeta, porcentaje} = datos;
  const totales = totalesPorDiaTarjeta;
  console.log("🚀 ~ file: ComportamientoGrafica.js:36 ~ ComportamientoGrafica ~ totales:", totales)
 
  // grafica en comportamiento
  const data = {
    labels: [
      // diaSemana,
      // diaSemana,
      // diaSemana,
      // diaSemana,
      // diaSemana,
      // diaSemana,
      // diaSemana,
      "Lunes",
      "Martes",
      "Miercoles",
      "Jueves",
      "Viernes",
      "Sabado",
      "Domingo"
    ],
    datasets: [
      {
        label: "Comercio1",
        borderColor: "rgba(255, 99, 132, 1)",
        backgroundColor: "rgba(255, 99, 132, 0)",
        data: [1, 19, 33, 45, 72, 93, 100],
      },
      // {
      //   label: "Delv2",
      //   borderColor: "rgba(54, 162, 235, 1)",
      //   backgroundColor: "rgba(54, 162, 235, 0)", 
      //   data: [5, 8, 33, 47, 69, 72, 86],
      // },
      // {
      //   label: "Suc1",
      //   borderColor: "#b4c400",
      //   backgroundColor: "rgba(180, 196, 0, 0)", 
      //   data: [6, 37, 42, 48, 54, 73, 77],
      // },
      // {
      //   label: "Suc2",
      //   borderColor: "#31008B",
      //   backgroundColor: "rgba(49, 0, 139, 0)", 
      //   data: [1, 17, 29, 42, 76, 86, 96],
      // },
      // {
      //   label: "Suc3",
      //   borderColor: "#08B",
      //   backgroundColor: "rgba(49, 0, 139, 0)", 
      //   data: [7, 12, 22, 32, 56, 76, 100],
      // },
      // {
      //   label: "Suc4",
      //   borderColor: "#080B",
      //   backgroundColor: "rgba(49, 0, 139, 0)", 
      //   data: [2, 18, 28, 38, 66, 86, 90],
      // },
    ],
  };

  const options = {
    plugins: {
      legend: {
        labels: {
          boxWidth: 8, 
          boxHeight: 8,
        },
        display: true,
        position: "bottom",
      },
    },
    responsive: true,
    scales: {
      y: {
        display: false, 
        grid: {
          display: false, 
        },
        ticks: {
          color: tickColor,
        },
      },
      x: {
        grid: {
          display: false, 
        },
        
        ticks: {
          color: tickColor,
          
        },
      },
    },
  };

  // grafica en Comparativa
  var beneficios = [comparativaHoymesanterior, comparativahoy];
  var meses = ["Noviembre", "Diciembre"];

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
        ticks: {
          color: tickColor,
        },
      },
      x: {
        grid: {
          display: false,
        },
        ticks: {
          color: tickColor,
        },
      },
    },
  };

  var midata = {
    labels: meses,
    datasets: [
      {
        label: "Beneficios",
        data: beneficios,
        backgroundColor: "#B4C400",
      },
    ],
  };

  midata.datasets.forEach(function (dataset) {
    dataset.barPercentage = 0.4;
    dataset.barThickness = 20; 
  });

  let numeroPorcentual = porcentaje || 0;
  console.log("🚀 ~ file: ComportamientoGrafica.js:180 ~ ComportamientoGrafica ~ numeroPorcentual:", numeroPorcentual)
  let porcentajeFinal = numeroPorcentual.toFixed(2); 
  console.log("🚀 ~ file: ComportamientoGrafica.js:181 ~ ComportamientoGrafica ~ porcentajeFinal:", porcentajeFinal)


  return (
    <section>
      <article className="container d-none d-md-block">
        <div className="row">
          <div className="mt-4 col-12 col-lg-6">
            <div
              style={{ paddingTop: "40px", height: "100%" }}
              className={
                darkMode
                  ? " bg-grafica-dark px-5 pb-4"
                  : "bg-grafica px-5 pb-4 "
              }
            >
              <h2 className="fs-18 text-center pb-3" style={{ top: "0%" }}>
                Facturación por rubro
              </h2>
              <div className="d-flex justify-content-center">
                <Line
                  className="px-3"
                  data={data}
                  options={options}
                />
              </div>
            </div>
          </div>
          <div className="mt-4 col-12 col-lg-6">
            <div className="d-flex justify-content-center ">
              <div
                style={{ paddingTop: "50px", height: "100%" }}
                className={
                  darkMode
                    ? " bg-grafica-dark px-5 pb-4 "
                    : "bg-grafica px-5 pb-4 "
                }
              >
                <h2 className="fs-18 text-center">
                  Comparativa (igual día mes anterior)
                </h2>
                <div className="d-flex justify-content-center ">
                  <Bar className="px-3" data={midata} options={misoptions} />
                </div>
                <div className="d-flex justify-content-center py-2">
                  <div
                    className={
                      darkMode
                        ? " btn-comparativa-dark centrado"
                        : "btn-comparativa centrado"
                    }
                  >
                    <div>
                      {/* <FontAwesomeIcon
                        className="color-verde me-2 fs-25"
                        icon={faCircleUp}
                      /> */}
                      <span className="lato-bold fs-18"> {porcentajeFinal} %</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </article>
      <article className="mt-3 d-md-none d-block container">
        <div className="row">
          <div className="my-2">
            <div className="d-flex justify-content-center ">
              <div
                className={
                  darkMode ? " bg-comportamiento-dark" : "bg-comportamiento"
                }
              >
                <h5 className="text-center py-4 lato-bold fs-16">
                  {" "}
                  Comportamiento de ventas
                </h5>
                <div className="d-flex justify-content-center">
                  <Line style={{ width: "100%" }} data={data} options={options} />
                </div>
              </div>
            </div>
          </div>
          <div className="my-2 ">
            <div className="d-flex justify-content-center ">
              <div
                className={
                  darkMode ? " bg-grafica-dark" : "bg-grafica"
                }
              >
                <h5 className="text-center py-4 lato-bold fs-16">
                  {" "}
                  Comparativa (igual día mes anterior)
                </h5>
                <div className="d-flex justify-content-center">
                  <Bar data={midata} options={misoptions} />
                </div>
                <div className="d-flex justify-content-center my-3">
                  <div
                    className={
                      darkMode
                        ? " btn-comparativa-dark centrado"
                        : "btn-comparativa centrado"
                    }
                  >
                    <div>
                      <div>
                        {/* <FontAwesomeIcon
                          className="color-rojo me-2 fs-25"
                          icon={faCircleUp}
                        /> */}
                        <span className="lato-bold fs-18"> {porcentajeFinal}%</span>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </article>
    </section>
  );
};

export default ComportamientoGrafica;
