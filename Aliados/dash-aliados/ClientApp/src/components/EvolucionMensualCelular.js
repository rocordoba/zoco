import React, { useContext, useEffect, useState, useRef } from "react";
import Chart from "chart.js/auto";
import { DarkModeContext } from "../context/DarkModeContext";

const EvolucionMensualCelular = () => {
  const { darkMode } = useContext(DarkModeContext);
  const color = darkMode ? "#fff" : "dark";
  const backgroundColor = darkMode ? "#fff" : "#292B2F";

  const chartRef = useRef(null); // Referencia al canvas de la gráfica
  const chartInstance = useRef(null); // Referencia a la instancia de Chart.js

  // Estado para controlar la visibilidad de las series de datos
  const [showPorMonto, setShowPorMonto] = useState(true);
  const [showPorCantidad, setShowPorCantidad] = useState(true);
  const [showAjusteInflacion, setShowAjusteInflacion] = useState(true);

  useEffect(() => {
    const data = {
      labels: [
        "Abril",
        "Mayo",
        "Junio",
        "Julio",
        "Agosto",
        "Septiembre",
        "Octubre",
      ],
      datasets: [
        {
          label: "Por monto",
          data: [1, 2, 3, 4, 5, 6, 7],
          backgroundColor: ["#b4c400"],
          borderWidth: 1,
          hidden: !showPorMonto, // Oculta si showPorMonto es falso
        },
        {
          label: "Por inflacion",
          data: [8, 6, 4, 9, 8, 7, 7, 8, 9],
          backgroundColor: [backgroundColor],
          borderWidth: 1,
          hidden: !showAjusteInflacion,
          // Oculta si showAjusteInflacion es falso
        },
        {
          label: " Por cantidad de operaciones",
          data: [7, 6, 5, 4, 3, 2, 1],
          backgroundColor: ["#B3B5BF"],
         
          borderWidth: 1,
          hidden: !showPorCantidad,
          // Oculta si showPorCantidad es falso
        },
 
      ],
    };

    const config = {
      type: "bar",
      data,
      options: {
        layout: {
          padding: {
            left: 35,
          },
        },
        indexAxis: "y",
        scales: {
          x: {
            beginAtZero: true,
            display: false,
            grid: {
              display: false,
            },
            ticks: {
              color,
              font: {
                size: 4,
              },
            },
          },
          y: {
            beginAtZero: true,
            display: true,
            grid: {
              display: false,
            },
            ticks: {
              color,
              font: {
                size: 10,
              },
            },
          },
        },
        plugins: {
          legend: {
            display: false,
          },
        },
      },
    };

    if (chartInstance.current) {
      chartInstance.current.destroy();
    }

    const ctx = chartRef.current;
    chartInstance.current = new Chart(ctx, config);
  }, [showPorMonto, showPorCantidad, showAjusteInflacion]);

  const togglePorMonto = () => {
    setShowPorMonto(!showPorMonto);
  };
  
  const toggleAjusteInflacion = () => {
    setShowAjusteInflacion(!showAjusteInflacion);
  };

  const togglePorCantidad = () => {
    setShowPorCantidad(!showPorCantidad);
  };


  const activadoMonto = () => {
    if (darkMode && showPorMonto) {
      return "btn-activar-monto ";
    } else if (darkMode) {
      return "btn-activar-monto-activo text-white ";
    } else if (showPorMonto) {
      return "btn-activar-monto";
    } else {
      return "btn-activar-monto-activo";
    }
  };

  const activadoInflacion = () => {
    if (darkMode && showAjusteInflacion) {
      return "btn-inflacion-activado-dark";
    } else if (darkMode) {
      return "btn-inflacion-desactivado-dark text-white ";
    } else if (showAjusteInflacion) {
      return "btn-activar-inflacion-activado";
    } else {
      return "btn-activar-inflacion-desactivado";
    }
  };

  const activadoOperacion = () => {
    if (darkMode && showPorCantidad) {
      return "btn-operaciones-activado ";
    } else if (darkMode) {
      return "btn-operaciones-desactivado-dark ";
    } else if (showPorCantidad) {
      return "btn-operaciones-activado";
    } else {
      return "btn-operaciones-desactivado";
    }
  };

  return (
    <div className="container">
      <div
        className={darkMode ? "bg-grafica-celular-dark" : "bg-grafica-celular"}
      >
        <div className="text-center pt-3">
          <h6 className="lato-bold fs-16">Evolución mensual</h6>
          <div className="d-flex justify-content-center flex-wrap my-2">
            <span className="fs-14">
              <button onClick={togglePorMonto} 
              className={activadoMonto()}>
                Por monto
              </button>
            </span>
          </div>

          <div className="d-flex justify-content-center flex-wrap my-2">
            <span className="fs-14">
              <button
                onClick={toggleAjusteInflacion }
                className={activadoInflacion()}
              >
                Por inflación
              </button>
            </span>
          </div>
          <div className="d-flex justify-content-center flex-wrap my-2">
            <span className="fs-14">
              <button
                onClick={togglePorCantidad }
               className={activadoOperacion()}
              >
                Por operaciones
              </button>
            </span>
          </div>
        </div>
        <canvas
          className="pe-5 ps-1"
          id="myChartEvolucionMensual"
          height="500"
          ref={chartRef}
        ></canvas>
      </div>
    </div>
  );
};

export default EvolucionMensualCelular;
