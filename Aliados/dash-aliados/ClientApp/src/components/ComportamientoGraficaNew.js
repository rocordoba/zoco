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

const ComportamientoGraficaNew = ({ datos }) => {
  console.log("🚀 ~ ComportamientoGrafica ~ datos:", datos);
  const { darkMode } = useContext(DarkModeContext);
  const tickColor = darkMode ? "#fff" : "#292B2F";

  const {
    comparativahoy,
    comparativaHoymesanterior,
    totalesPorDiaTarjeta,
    porcentaje,
  } = datos;
  const totales = totalesPorDiaTarjeta || [];

  const tiendas = Object.keys(totales);

  // Crear un array para almacenar los días
  let diasArray = [];
  // Iterar sobre cada tienda
  for (let tienda in totales) {
    if (totales.hasOwnProperty(tienda)) {
      // Obtener los días de esa tienda y añadirlos al array
      diasArray = diasArray.concat(totales[tienda].map(valor => valor.key));
    }
    
  }
  // Si quieres eliminar duplicados, convierte el array en un Set y luego de nuevo en un array
  diasArray = [...new Set(diasArray)];

  function ordenarDias(dia) {
    const orden = {
      lunes: 1,
      martes: 2,
      miércoles: 3,
      jueves: 4,
      viernes: 5,
      sábado: 6,
      domingo: 7
    };
    return orden[dia] || 8;
  }
  
  diasArray.sort((a, b) => ordenarDias(a) - ordenarDias(b));


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

  const datasets = tiendas.map((tienda) => {
    const valoresTienda = totales[tienda];
    console.log("🚀 ~ datasets ~ valoresTienda:", valoresTienda)
    const dias = valoresTienda.map((valor) => valor.diaSemana);
    const totalConDescuentoPorDias = valoresTienda.map(
      (valor) => valor.value
    );
    console.log("🚀 ~ datasets ~ totalConDescuentoPorDias:", totalConDescuentoPorDias)

    return {
      label: tienda,
      borderColor: `rgba(${Math.floor(Math.random() * 256)}, ${Math.floor(
        Math.random() * 256
      )}, ${Math.floor(Math.random() * 256)}, 1)`,
      backgroundColor: `rgba(${Math.floor(Math.random() * 256)}, ${Math.floor(
        Math.random() * 256
      )}, ${Math.floor(Math.random() * 256)}, 0)`,
      data: totalConDescuentoPorDias,
    };
  });

  const data = {
    labels: diasArray,
    datasets: datasets,
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
        </div>
      </article>
    </section>
  );
};

export default ComportamientoGraficaNew;
