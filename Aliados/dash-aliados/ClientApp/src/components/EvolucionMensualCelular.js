import React, { useContext, useEffect, useState, useRef } from "react";
import Chart from "chart.js/auto";
import { DarkModeContext } from "../context/DarkModeContext";

const EvolucionMensualCelular = ({ datosBack}) => {
  const { darkMode } = useContext(DarkModeContext);
  const color = darkMode ? "#fff" : "dark";
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

  const chartRef = useRef(null); // Referencia al canvas de la gráfica
  const chartInstance = useRef(null); // Referencia a la instancia de Chart.js

  // Estado para controlar la visibilidad de las series de datos
  const [showPorMonto, setShowPorMonto] = useState(true);
  const [showPorCantidad, setShowPorCantidad] = useState(true);
  const [showAjusteInflacion, setShowAjusteInflacion] = useState(true);

  useEffect(() => {
    const data = {
      labels: meses,
      datasets: [
        {
          label: "Por monto $",
          // data: [1, 2, 3, 4, 5, 6, 7],
          data: totalBruto || [],
          backgroundColor: ["#b4c400"],
          borderWidth: 1,
          hidden: !showPorMonto, // Oculta si showPorMonto es falso
        },
        {
          label: "Por inflacion $",
          data: totalBrutoInflacion || [],
          backgroundColor: [backgroundColor],
          borderWidth: 1,
          hidden: !showAjusteInflacion,
          // Oculta si showAjusteInflacion es falso
        },
        {
          label: " Por cantidad de operaciones $",
          data: operaciones || [],
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
  }, [showPorMonto, showPorCantidad, showAjusteInflacion,datosResumenUltimosMeses]);

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
              <button onClick={togglePorMonto} className={activadoMonto()}>
                Por monto
              </button>
            </span>
          </div>

          <div className="d-flex justify-content-center flex-wrap my-2">
            <span className="fs-14">
              <button
                onClick={toggleAjusteInflacion}
                className={activadoInflacion()}
              >
                Por inflación
              </button>
            </span>
          </div>
          <div className="d-flex justify-content-center flex-wrap my-2">
            <span className="fs-14">
              <button
                onClick={togglePorCantidad}
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
