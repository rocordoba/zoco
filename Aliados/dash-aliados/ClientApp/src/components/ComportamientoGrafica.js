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
import {
  faCircleUp,
  faCircleArrowDown,
  faCirclePause,
} from "@fortawesome/free-solid-svg-icons";
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

const ComportamientoGrafica = ({ datos }) => {
  const { darkMode } = useContext(DarkModeContext);
  const tickColor = darkMode ? "#fff" : "#292B2F";

  const {
    comparativahoy,
    comparativaHoymesanterior,
    totalesPorDiaTarjeta,
    porcentaje,
  } = datos;
  const totales = totalesPorDiaTarjeta || [];

  // const valoresTiendaABC = totales["TiendaABC"];
  // const dias = valoresTiendaABC.map((valor) => valor.diaSemana);
  // const totalConDescuentoPorDia = valoresTiendaABC.map(
  //   (valor) => valor.totalConDescuentoPorDia
  // );

  // const valoresTienditaABC = totales["TienditaABC"];
  // const diasTienda2 = valoresTienditaABC.map((valor) => valor.diaSemana);
  // const totalConDescuentoPorDiaTienda2 = valoresTienditaABC.map(
  //   (valor) => valor.totalConDescuentoPorDia
  // );

  // grafica en comportamiento
  // const data = {
  //   labels: dias,
  //   datasets: [
  //     {
  //       label: "Comercio1",
  //       borderColor: "rgba(255, 99, 132, 1)",
  //       backgroundColor: "rgba(255, 99, 132, 0)",
  //       data: totalConDescuentoPorDia,
  //     },
  //      {
  //       label: "Delv2",
  //       borderColor: "rgba(54, 162, 235, 1)",
  //       backgroundColor: "rgba(54, 162, 235, 0)",
  //       data: totalConDescuentoPorDiaTienda2,
  //     },
  //     // {
  //     //   label: "Suc1",
  //     //   borderColor: "#b4c400",
  //     //   backgroundColor: "rgba(180, 196, 0, 0)",
  //     //   data: [6, 37, 42, 48, 54, 73, 77],
  //     // },
  //     // {
  //     //   label: "Suc2",
  //     //   borderColor: "#31008B",
  //     //   backgroundColor: "rgba(49, 0, 139, 0)",
  //     //   data: [1, 17, 29, 42, 76, 86, 96],
  //     // },
  //     // {
  //     //   label: "Suc3",
  //     //   borderColor: "#08B",
  //     //   backgroundColor: "rgba(49, 0, 139, 0)",
  //     //   data: [7, 12, 22, 32, 56, 76, 100],
  //     // },
  //     // {
  //     //   label: "Suc4",
  //     //   borderColor: "#080B",
  //     //   backgroundColor: "rgba(49, 0, 139, 0)",
  //     //   data: [2, 18, 28, 38, 66, 86, 90],
  //     // },
  //   ],
  // };

  // const options = {
  //   plugins: {
  //     legend: {
  //       labels: {
  //         boxWidth: 8,
  //         boxHeight: 8,
  //       },
  //       display: true,
  //       position: "bottom",
  //     },
  //   },
  //   responsive: true,
  //   scales: {
  //     y: {
  //       display: false,
  //       grid: {
  //         display: false,
  //       },
  //       ticks: {
  //         color: tickColor,
  //       },
  //     },
  //     x: {
  //       grid: {
  //         display: false,
  //       },

  //       ticks: {
  //         color: tickColor,
  //       },
  //     },
  //   },
  // };

  const tiendas = Object.keys(totales);
  // Obtener los días únicos de todas las tiendas
  const diasUnicos = tiendas.reduce((dias, tienda) => {
    const valoresTienda = totales[tienda];
    const diasTienda = valoresTienda.map((valor) => valor.diaSemana);
    return [...new Set([...dias, ...diasTienda])]; // Unir y obtener días únicos
  }, []);

  const datasets = tiendas.map((tienda) => {
    const valoresTienda = totales[tienda];
    const dias = valoresTienda.map((valor) => valor.diaSemana);
    const totalConDescuentoPorDia = valoresTienda.map(
      (valor) => valor.totalConDescuentoPorDia
    );

    return {
      label: tienda,
      borderColor: `rgba(${Math.floor(Math.random() * 256)}, ${Math.floor(
        Math.random() * 256
      )}, ${Math.floor(Math.random() * 256)}, 1)`,
      backgroundColor: `rgba(${Math.floor(Math.random() * 256)}, ${Math.floor(
        Math.random() * 256
      )}, ${Math.floor(Math.random() * 256)}, 0)`,
      data: totalConDescuentoPorDia,
    };
  });

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

  const data = {
    labels: diasUnicos ,
    datasets: datasets,
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
        label: "Monto$",
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
  let porcentajeFinal = numeroPorcentual.toFixed(2);
  let porcentajeNumero = porcentajeFinal;

  const mostrarIcono = () => {
    if (porcentajeNumero > 0) {
      return (
        <div>
          <FontAwesomeIcon
            className="color-verde me-2 fs-25"
            icon={faCircleUp}
          />
        </div>
      );
    } else if (porcentajeNumero === 0) {
      return (
        <div>
          <FontAwesomeIcon
            className="color-negro me-2 fs-25 fa-rotate-90"
            icon={faCirclePause}
          />
        </div>
      );
    } else {
      return (
        <div>
          <FontAwesomeIcon
            className="color-rojo me-2 fs-25"
            icon={faCircleArrowDown}
          />
        </div>
      );
    }
  };

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
                <Line className="px-3" data={data} options={options} />
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
                    <div className="d-flex">
                      <div>{mostrarIcono()}</div>
                      <span className="lato-bold fs-18">
                        {porcentajeFinal} %
                      </span>
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
                  <Line
                    style={{ width: "100%" }}
                    data={data}
                    options={options}
                  />
                </div>
              </div>
            </div>
          </div>
          <div className="my-2 ">
            <div className="d-flex justify-content-center ">
              <div className={darkMode ? " bg-grafica-dark" : "bg-grafica"}>
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
                      <div className="d-flex">
                        <div>{mostrarIcono()}</div>
                        <span className="lato-bold fs-18">
                          {porcentajeFinal} %
                        </span>
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
