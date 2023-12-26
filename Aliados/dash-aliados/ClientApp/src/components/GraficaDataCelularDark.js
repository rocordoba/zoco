import React, { useContext, useEffect, useState } from "react";
import Chart from "chart.js/auto";
import amexPNG from "../assets/img/amex-blanco.png";

import argencardPNG from "../assets/img/argencard-blanco.png";

import cabalPNG from "../assets/img/cabal-blanco.png";

import dinersPNG from "../assets/img/diners-blanco.png";

import masterPNG from "../assets/img/mastercard-blanco.png";

import naranjaxPNG from "../assets/img/naranjax-blanco.png";

import visaPNG from "../assets/img/visa-blanco.png";

import { DarkModeContext } from "../context/DarkModeContext";;

const GraficaDataCelularDark = ({datos}) => {
  const { darkMode } = useContext(DarkModeContext);

  const descuentosPorTarjeta = datos.descuentosPorTarjeta || [];

   // Crear un objeto para mapear los datos dinámicos
  const dataTarjeta = descuentosPorTarjeta.map(item => ({
    totalConDescuento: item.totalConDescuento
  }));

  const numerosTarjeta = dataTarjeta.map(item => item.totalConDescuento)

  useEffect(() => {
    // setup
    const data = {
      labels: ["", "", "", "", "", "", ""],
      datasets: [
        {
          label: "",
          data: numerosTarjeta ,
          backgroundColor: ["#b4c400 "],
          borderColor: ["#b4c400 "],
          borderWidth: 1,
          image: [
            `${amexPNG}`,
            `${argencardPNG}`,
            `${cabalPNG}`,
            `${dinersPNG}`,
            `${masterPNG}`,
            `${naranjaxPNG}`,
            `${visaPNG}`,
          ],
        },
      ],
    };
    // configuracion de las imagenes de las tarjetas
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

        data.datasets[0].image.forEach((imageLink, index) => {
          const logo = new Image();
          logo.src = imageLink;
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
              font: {
                size: 9,
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
              font: {
                size: 9,
              },
            },
          },
        },
        plugins: {
          legend: {
            display: false, // para mostrar la leyenda
          },
        },
      },

      plugins: [imageItems],
    };

    const ctx = document.getElementById("myChart");
    const existingChart = Chart.getChart(ctx); // Obtener el gráfico existente en el lienzo
  
    // Si ya hay un gráfico en el lienzo, destrúyelo antes de crear uno nuevo
    if (existingChart) {
      existingChart.destroy();
    }
  
    new Chart(ctx, config); // Crear un nuevo gráfico
  }, [descuentosPorTarjeta]);
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