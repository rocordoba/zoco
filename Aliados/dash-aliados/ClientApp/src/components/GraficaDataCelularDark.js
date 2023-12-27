import React, { useContext, useEffect } from "react";
import Chart from "chart.js/auto";
import amexPNG from "../assets/img/amex-blanco.png";
import argencardPNG from "../assets/img/argencard-blanco.png";
import cabalPNG from "../assets/img/cabal-blanco.png";
import dinersPNG from "../assets/img/diners-blanco.png";
import masterPNG from "../assets/img/mastercard-blanco.png"
import naranjaxPNG from "../assets/img/naranjax-blanco.png";
import visaPNG from "../assets/img/visa-blanco.png";
import { DarkModeContext } from "../context/DarkModeContext";

const GraficaDataCelularDark = ({ datos }) => {
  const { darkMode } = useContext(DarkModeContext);
  const descuentosPorTarjeta = datos.descuentosPorTarjeta || [];

  // Crear un objeto para mapear los datos dinámicos
  const dataTarjeta = descuentosPorTarjeta.map((item) => ({
    totalConDescuento: item.totalConDescuento,
  }));

  const numerosTarjeta = dataTarjeta.map((item) => item.totalConDescuento);

  // Ordenar beneficios de mayor a menor
  numerosTarjeta.sort((a, b) => b - a);

  // Crear un array con los nombres de las tarjetas ordenados según los beneficios
  const tarjetasOrdenadas = [
    "Visa",
    "MasterCard",
    "Argencard",
    "Amex",
    "Diners",
    "Cabal",
    "Naranjax",
  ];

  const imagenes = {
    Visa: visaPNG,
    MasterCard: masterPNG,
    Argencard: argencardPNG,
    Amex: amexPNG,
    Diners: dinersPNG,
    Cabal: cabalPNG,
    Naranjax: naranjaxPNG,
  };

  useEffect(() => {
    const imageItems = {
      id: "imageItems",
      beforeDatasetsDraw(chart, args, pluginOptions) {
        const {
          ctx,
          options,
          data,
          scales: { y },
        } = chart;

        ctx.save();
        const imageSize = options.layout.padding.left;

        data.datasets[0].image.forEach((_, index) => {
          const logo = new Image();
          const tarjeta = tarjetasOrdenadas[index];
          logo.src = imagenes[tarjeta];
          ctx.drawImage(
            logo,
            0,
            y.getPixelForValue(index) - imageSize / 2,
            imageSize,
            imageSize
          );
        });
      },
    };

    const config = {
      type: "bar",
      data: {
        labels: tarjetasOrdenadas,
        datasets: [
          {
            label: "",
            data: numerosTarjeta,
            backgroundColor: ["#b4c400"],
            borderColor: ["#b4c400"],
            borderWidth: 1,
            image: [
              visaPNG,
              masterPNG,
              argencardPNG,
              amexPNG,
              dinersPNG,
              cabalPNG,
              naranjaxPNG,
            ],
          },
        ],
      },
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
              font: {
                size: 9,
              },
            },
          },
          y: {
            beginAtZero: true,
            display: false,
            grid: {
              display: false,
            },
            ticks: {
              font: {
                size: 9,
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
      plugins: [imageItems],
    };

    const ctx = document.getElementById("myChart");
    const existingChart = Chart.getChart(ctx);

    if (existingChart) {
      existingChart.destroy();
    }

    new Chart(ctx, config);
  }, [descuentosPorTarjeta, imagenes, numerosTarjeta, tarjetasOrdenadas]);

  return (
    <div className="container">
      <div
        className={
          darkMode ? " bg-grafica-celular-dark px-4" : "bg-grafica-celular px-4"
        }
      >
        <canvas className="" id="myChart" height="400"></canvas>
      </div>
    </div>
  );
};

export default GraficaDataCelularDark;
