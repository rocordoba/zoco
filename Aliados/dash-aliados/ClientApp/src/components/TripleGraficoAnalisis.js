import { Bar } from "react-chartjs-2";
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
import {
  faCircleArrowDown,
  faCirclePause,
  faCircleUp,
} from "@fortawesome/free-solid-svg-icons";
import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import convertirDecimalAPorcentaje from "../helpers/convertirPorcentajeADecimal";

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
    creditoFacturacion,
    debitoFacturacion,
    porcentajeporcuotas,
    porcentajeticket,
    porcentajetipopago,
    cuotas,
  } = datosBack;

  let numeroPorcentual = porcentajeporcuotas || 0;
  let porcentajeFinal = numeroPorcentual.toFixed(2);
  let porcentajeEnteroCuotas = convertirDecimalAPorcentaje(porcentajeFinal);

  let numeroPorcentualTicket = porcentajeticket || 0;
  let porcentajeFinalTicket = numeroPorcentualTicket.toFixed(2);
  let porcentajeEnteroFinalTicket = convertirDecimalAPorcentaje(
    porcentajeFinalTicket
  );

  let numeroPorcentualTipoPago = porcentajetipopago || 0;
  let porcentajeFinalTipoPago = numeroPorcentualTipoPago.toFixed(2);
  let porcentajeEnteroTipoPago = convertirDecimalAPorcentaje(
    porcentajeFinalTipoPago
  );

  // let porcentajeNumero = porcentajeFinal;

  // const mostrarIcono = () => {
  //   if (porcentajeNumero > 0) {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-verde me-2 fs-25"
  //           icon={faCircleUp}
  //         />
  //       </div>
  //     );
  //   } else if (porcentajeNumero === 0) {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-negro me-2 fs-25 fa-rotate-90"
  //           icon={faCirclePause}
  //         />
  //       </div>
  //     );
  //   } else {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-rojo me-2 fs-25"
  //           icon={faCircleArrowDown}
  //         />
  //       </div>
  //     );
  //   }
  // };

  // let porcentajeNumeroTipoPago = porcentajeFinalTipoPago;

  // const mostrarIconoTipoPago = () => {
  //   if (porcentajeNumeroTipoPago > 0) {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-verde me-2 fs-25"
  //           icon={faCircleUp}
  //         />
  //       </div>
  //     );
  //   } else if (porcentajeNumeroTipoPago === 0) {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-negro me-2 fs-25 fa-rotate-90"
  //           icon={faCirclePause}
  //         />
  //       </div>
  //     );
  //   } else {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-rojo me-2 fs-25"
  //           icon={faCircleArrowDown}
  //         />
  //       </div>
  //     );
  //   }
  // };

  // let porcentajeNumeroTicket = porcentajeFinalTicket;

  // const mostrarIconoTicket = () => {
  //   if (porcentajeNumeroTicket > 0) {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-verde me-2 fs-25"
  //           icon={faCircleUp}
  //         />
  //       </div>
  //     );
  //   } else if (porcentajeNumeroTicket === 0) {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-negro me-2 fs-25 fa-rotate-90"
  //           icon={faCirclePause}
  //         />
  //       </div>
  //     );
  //   } else {
  //     return (
  //       <div>
  //         <FontAwesomeIcon
  //           className="color-rojo me-2 fs-25"
  //           icon={faCircleArrowDown}
  //         />
  //       </div>
  //     );
  //   }
  // };

  // FACTURACION POR CUOTA
  var beneficios = [debitoFacturacion, creditoFacturacion];
  var labels = ["Débito", "Crédito"];
    var misoptions = {
        responsive: true,
        plugins: {
            legend: {
                display: false,
            },
            tooltip: {
                enabled: true,
                mode: 'index',
                intersect: false,
                callbacks: {
                    label: function (context) {
                        let label = context.dataset.label || '';
                        if (label) {
                            label += ': ';
                        }
                        label += context.parsed.y.toFixed(2); // Redondear a 2 decimales
                        return label;
                    }
                }
            }
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
  var ticketValues = [debito, credito];

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

    const cuotasExtraidas = cuotas || [];
    const cuotasFiltradas = cuotasExtraidas.filter((cuota) => cuota.cuota !== 0);
    const cuotasOrdenadasPorCuota = cuotasFiltradas.sort((a, b) => a.cuota - b.cuota);

    var beneficios = cuotasOrdenadasPorCuota.map((cuota) => cuota.totalBruto || 0);
    var cuotasOrdenadas = cuotasOrdenadasPorCuota.map((cuota) => cuota.cuota);

    var midataVentas = {
        labels: cuotasOrdenadas,
        datasets: [
            {
                label: "Monto$",
                data: beneficios,
                backgroundColor: "#B4C400",
            },
        ],
    };

    midataVentas.datasets.forEach(function (dataset) {
        dataset.barPercentage = 1;
        dataset.barThickness = 30;
    });

    // Configuración de opciones para midataVentas
    const opcionesVentas = {
        plugins: {
            tooltip: {
                enabled: true,
                mode: 'index',
                intersect: false,
                callbacks: {
                    label: function (context) {
                        let label = context.dataset.label || '';
                        if (label) {
                            label += ': ';
                        }
                        label += context.parsed.y.toFixed(2); // Redondear a 2 decimales
                        return label;
                    }
                }
            }
        },
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    color: tickColor, // Utiliza el color dinámico aquí
                }
            },
            x: {
                ticks: {
                    color: tickColor,
                }
            }
        },
        // ... otras opciones que desees configurar
    };

    // Suponiendo que estás utilizando Chart.js, aquí está la configuración de los tooltips
   


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
              Ventas por tipo de pago
            </h2>
            <div className="d-flex justify-content-center ">
              <Bar
                className="mx-4 my-4"
                data={midataFacturacion}
                options={misoptions}
              />
            </div>
            <div>
              <h6 className="fs-9 lato-bold text-center">
                {" "}
                Diferencia entre Débito y Crédito
              </h6>
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
                  <div className="d-flex">
                    <span className="lato-bold fs-18">
                      {porcentajeEnteroCuotas} %
                    </span>
                  </div>
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
            <div>
              <h6 className="fs-9 lato-bold text-center">
                Diferencia entre Débito y Crédito
              </h6>
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
                  <div className="d-flex">
                    <span className="lato-bold fs-18">
                      {porcentajeEnteroFinalTicket} %
                    </span>
                  </div>
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
              Facturación por tipo de cuota
            </h2>
            <div className="d-flex justify-content-center ">
              <Bar
                className="mx-4 my-4"
                data={midataVentas}
                options={misoptions}
              />
            </div>
          </div>
        </article>
      </div>
    </section>
  );
};

export default TripleGraficoAnalisis;
