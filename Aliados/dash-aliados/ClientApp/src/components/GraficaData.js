import { Bar } from "react-chartjs-2";
import "./GraficaData.css";
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
import TarjetasLogo from "./TarjetasLogo";
import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import TarjetasLogoBlanco from "./TarjetasLogoBlanco";

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

const GraficaData = ({ datos }) => {
  const { descuentosPorTarjeta } = datos || {};
  
  const [
    visa = {},
    masterCard = {},
    cabal = {},
    argencard = {},
    amex = {},
    diners = {},
    naranjax = {},
  ] = descuentosPorTarjeta || [];

  const visaTotalDescuento = visa.totalConDescuento || 0;
  const masterCardTotalDescuento = masterCard.totalConDescuento || 0;
  const cabalTotalDescuento = cabal.totalConDescuento || 0;
  const argencardTotalDescuento = argencard.totalConDescuento || 0;
  const amexTotalDescuento = amex.totalConDescuento || 0;
  const dinersTotalDescuento = diners.totalConDescuento || 0;
  const naranjaxTotalDescuento = naranjax.totalConDescuento || 0;

  var beneficios = [
    visaTotalDescuento,
    masterCardTotalDescuento,
    cabalTotalDescuento,
    argencardTotalDescuento,
    amexTotalDescuento,
    dinersTotalDescuento,
    naranjaxTotalDescuento,
  ];
  // Ordenar beneficios de mayor a menor
  beneficios.sort((a, b) => b - a);

  // var beneficios = [1, 2, 3, 4, 5, 6, 7]
  var tarjetas = ["Visa", "MasterCard", "Cabal", "Argencard", "Amex", "Diners", "Naranjax"];

  // Obtener el índice original de la tarjeta después de ordenar los beneficios
  var tarjetasOrdenadas = tarjetas.slice().sort(function (a, b) {
    return beneficios[tarjetas.indexOf(b)] - beneficios[tarjetas.indexOf(a)];
  });

  const { darkMode } = useContext(DarkModeContext);
  const tickColor = darkMode ? "#fff" : "#292B2F";
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
          color: darkMode ? "blue" : "red",
          borderColor: "transparent",
        },
      },
      x: {
        display: false,
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
    labels: tarjetas,
    datasets: [
      {
        label: "Monto$",
        data: beneficios,
        backgroundColor: "#B4C400",
      },
    ],
  };

  midata.datasets.forEach(function (dataset) {
    dataset.barPercentage = 1;
    dataset.barThickness = 40;
  });

  return (
    <section className="container ">
      <article
        className={
          darkMode
            ? " bg-grafica-dark px-5 pb-4 position-relative"
            : "bg-grafica position-relative px-5 pb-3"
        }
      >
        <h2
          className="fs-18 py-4 position-absolute start-50 translate-middle-x"
          style={{ top: "3%" }}
        >
          Facturación por tarjeta
        </h2>

        <Bar
          className="padding-top-grafica "
          data={midata}
          options={misoptions}
        />
        {darkMode ? (
          <>
            <TarjetasLogoBlanco  tarjetasOrdenadas={tarjetasOrdenadas}/>
          </>
        ) : (
          <>
            <TarjetasLogo  tarjetasOrdenadas={tarjetasOrdenadas}/>
          </>
        )}
      </article>
    </section>
  );
};

export default GraficaData;
