import { Bar } from "react-chartjs-2";
import formatearValores from "../helpers/formatearAPeso";
import "./TripleGraficoAnalisis.css";
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
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCirclePause } from "@fortawesome/free-solid-svg-icons";
import { useContext } from "react";
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

const TripleGraficoAnalisis = ({ datosBack }) => {
  const { darkMode } = useContext(DarkModeContext);
  const tickColor = darkMode ? "#fff" : "#292B2F";

  const {
    debito,
    credito,
    totalConDescuentoCuotas0,
    totalConDescuentoCuotas1,
  } = datosBack;



  // FACTURACION POR CUOTA
  var beneficios = [debito, credito];
  var labels = ["Débito", "Crédito"];

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
            size: 12,
          },
        },
      },
    },
  };

  var midataFacturacion = {
    labels: labels,
    datasets: [
      {
        label: "Valores",
        data: beneficios,
        backgroundColor: "#B4C400",
      },
    ],
  };

  midataFacturacion.datasets.forEach(function (dataset) {
    dataset.barPercentage = 0.4;
    dataset.barThickness = 30;
  });

  // TICKET PROMEDIO 
  var ticketValues = [52, 96];

  var midataTickets = {
    labels: labels,
    datasets: [
      {
        label: "Valores",
        data: ticketValues,
        backgroundColor: "#B4C400",
      },
    ],
  };

  midataTickets.datasets.forEach(function (dataset) {
    dataset.barPercentage = 0.4;
    dataset.barThickness = 30;
  });

  // VENTAS POR TIPO DE PAGO
  var ventasValues = [totalConDescuentoCuotas0, totalConDescuentoCuotas1];

  var midataVentas = {
    labels: labels,
    datasets: [
      {
        label: "Valores",
        data: ventasValues,
        backgroundColor: "#B4C400",
      },
    ],
  };

  midataVentas.datasets.forEach(function (dataset) {
    dataset.barPercentage = 0.4;
    dataset.barThickness = 30;
  });

  return (
    <section className="container py-analisis-grafica">
      <div className="row">
        <article className="col-12 col-lg-4 my-2">
          <div
            style={{ paddingTop: "0px", height: "100%" }}
            className={
              darkMode ? " bg-grafica-dark px-5 pb-4" : "bg-grafica px-5 pb-4"
            }
          >
            <h2 className="fs-18-a-16 py-4 text-center">
              Facturación por cuota
            </h2>
            <div className="d-flex justify-content-center ">
              <Bar
                className="mx-4 my-4"
                data={midataFacturacion}
                options={misoptions}
              />
            </div>
            <div className="d-flex justify-content-center ">
              <div
                className={
                  darkMode
                    ? " btn-comparativa-dark centrado"
                    : "btn-comparativa centrado"
                }
              >
                <div>
                  <FontAwesomeIcon
                    className=" me-2 fs-26-a-18 fa-rotate-90"
                    icon={faCirclePause}
                  />
                  <span className="lato-bold fs-26-a-18"> 30%</span>
                </div>
              </div>
            </div>
          </div>
        </article>
        <article className="col-12 col-lg-4 my-2">
          <div
            style={{ paddingTop: "0px", height: "100%" }}
            className={
              darkMode ? " bg-grafica-dark px-5 pb-4" : "bg-grafica px-5 pb-4"
            }
          >
            <h2 className="fs-18-a-16 py-4 text-center">Ticket promedio</h2>
            <div className="d-flex justify-content-center ">
              <Bar
                className="mx-4 my-4"
                data={midataTickets}
                options={misoptions}
              />
            </div>
            <div className="d-flex justify-content-center ">
              <div
                className={
                  darkMode
                    ? " btn-comparativa-dark centrado"
                    : "btn-comparativa centrado"
                }
              >
                <div>
                  <FontAwesomeIcon
                    className=" me-2 fs-26-a-18 fa-rotate-90"
                    icon={faCirclePause}
                  />
                  <span className="lato-bold fs-26-a-18"> 30%</span>
                </div>
              </div>
            </div>
          </div>
        </article>
        <article className="col-12 col-lg-4 my-2">
          <div
            style={{ paddingTop: "0px", height: "100%" }}
            className={
              darkMode ? " bg-grafica-dark px-5 pb-4" : "bg-grafica px-5 pb-4"
            }
          >
            <h2 className="fs-18-a-16 py-4 text-center">
              Ventas por tipo de pago
            </h2>
            <div className="d-flex justify-content-center ">
              <Bar
                className="mx-4 my-4"
                data={midataVentas}
                options={misoptions}
              />
            </div>
            <div className="d-flex justify-content-center ">
              <div
                className={
                  darkMode
                    ? " btn-comparativa-dark centrado"
                    : "btn-comparativa centrado"
                }
              >
                <div>
                  <FontAwesomeIcon
                    className=" me-2 fs-26-a-18 fa-rotate-90"
                    icon={faCirclePause}
                  />
                  <span className="lato-bold fs-26-a-18"> 30%</span>
                </div>
              </div>
            </div>
          </div>
        </article>
      </div>
    </section>
  );
};

export default TripleGraficoAnalisis;
