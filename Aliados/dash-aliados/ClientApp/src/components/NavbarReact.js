import "./NavbarReact.css";
import {
  faBell,
  faCalculator,
  faCircle,
  faFileInvoiceDollar,
  faFilter,
  faGear,
  faHouse,
  faMagnifyingGlassChart,
  faMoon,
  faReceipt,
  faRightFromBracket,
  faStar,
  faSun,
  faUser,
  faXmark,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useContext, useState } from "react";
import { NavLink } from "react-router-dom";
import logo from "../assets/img/logo.png";
import logoClaro from "../assets/img/logo-modo-oscuro.png";
import { FaBars } from "react-icons/fa";
import trianguloModal from "../assets/img/triangulomodales.png";
import { DarkModeContext } from "../context/DarkModeContext";
import Select from "react-select";
import { faWhatsapp } from "@fortawesome/free-brands-svg-icons";

import { Button, Modal } from "react-bootstrap";
import { useForm, Controller } from "react-hook-form";

import { DatosInicioContext } from "../context/DatosInicioContext";
import Swal from "sweetalert2";

function NavbarReact({ visible, show, disableScroll, enableScroll }) {
  //switch claro/oscuro
  const { toggleDarkMode } = useContext(DarkModeContext);

  const ocultar = () => {
    show(!visible);
    disableScroll();
    setVisible1(false);
    setVisible2(false);
  };

  const aparecerScroll = () => {
    show(!visible);
    enableScroll();
  };

  const [datosCapturadosPanel, setDatosCapturadosPanel] = useState({});
  console.log(
    "🚀 ~ file: NavbarReact.js:86 ~ NavbarReact ~ setDatosCapturadosPanel:",
    setDatosCapturadosPanel
  );
  console.log(
    "🚀 ~ file: NavbarReact.js:35 ~ NavbarReact ~ datosCapturadosPanel:",
    datosCapturadosPanel
  );

  const [visible1, setVisible1] = useState(false);
  const verModalNotificacion = () => {
    setVisible1(!visible1);
    setVisible2(false);
  };

  const [visible2, setVisible2] = useState(false);
  const verModalCerrarSesion = () => {
    setVisible2(!visible2);
    setVisible1(false);
  };

  const [visibleModal, setVisibleModal] = useState(false);

  const verModalFilter = () => {
    setVisible2(false);
    setVisible1(false);
    setVisibleModal(!visibleModal);
  };

  const [datoCapturados, setDatoCapturados] = useState({});
  const [isSearchable, setIsSearchable] = useState(true);
  const [selectedAnio, setSelectedAnio] = useState(null);
  const [selectedMes, setSelectedMes] = useState(null);
  const [selectedComercio, setSelectedComercio] = useState(null);
  const [selectedSemana, setSelectedSemana] = useState(null);
  console.log("🚀 ~ BienvenidoPanel ~ selectedSemana:", selectedSemana);

  const { actualizarDatos } = useContext(DatosInicioContext);
  const [fechaInicio, setFechaInicio] = useState(null);
  const [fechaFin, setFechaFin] = useState(null);
  const [optionsComercio, setOptionsComercio] = useState([]);
  const [optionsAnios, setOptionsAnios] = useState([]);
  const [optionsMes, setOptionsMes] = useState([]);
  const [optionsSemanas, setOptionsSemanas] = useState([]);

  const [datosSelect, setDatosSelect] = useState({
    anio: "",
    mes: "",
    semana: "",
    comercio: "",
  });
  console.log("🚀 ~ BienvenidoPanel ~ datosSelect:", datosSelect);

  const enviarDatosAlContexto = (datos) => {
    actualizarDatos(datos);
  };

  const procesarDatos = (data) => {
    console.log("Respuesta de la API:", data);

    const optionsComercio = data.comercios.map((comercio) => ({
      value: comercio.toLowerCase().replace(/\s+/g, ""),
      label: comercio,
    }));

    const fechaInicio = new Date(data.fechaInicio);
    const fechaFin = new Date(data.fechaFin);

    const optionsAnios = [];
    for (
      let año = fechaInicio.getFullYear();
      año <= fechaFin.getFullYear();
      año++
    ) {
      optionsAnios.push({ value: año.toString(), label: año.toString() });
    }

    const optionsMeses = [];
    let fechaActual = fechaInicio;
    while (fechaActual <= fechaFin) {
      const mes = fechaActual.toLocaleString("es", { month: "long" });
      optionsMeses.push({ value: mes.toLowerCase(), label: mes });
      fechaActual = new Date(
        fechaActual.getFullYear(),
        fechaActual.getMonth() + 1,
        1
      );
    }

    setOptionsComercio(optionsComercio);
    setOptionsAnios(optionsAnios);
    setOptionsMes(optionsMeses);
    setOptionsSemanas(optionsSemanas);
    setFechaInicio(fechaInicio);
    setFechaFin(fechaFin);
  };

  useEffect(() => {
    const token = sessionStorage.getItem("token");
    const userId = localStorage.getItem("userId");

    const requestData = {
      token: token,
      id: userId,
    };

    if (token && userId) {
      fetch("/api/bienvenidopanel/bienvenidopanel", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestData),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("Error en la solicitud");
          }
          return response.json();
        })
        .then((data) => {
          console.log("Datos recibidos de la API:", data);
          procesarDatos(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, []);
  const actualizarMesesPorAnio = (anioSeleccionado) => {
    if (!fechaInicio || !fechaFin) return;
    setDatosSelect({
      anio: parseInt(anioSeleccionado),
    });
    const mesInicio =
      new Date(anioSeleccionado, 0, 1).getFullYear() ===
      fechaInicio.getFullYear()
        ? fechaInicio.getMonth()
        : 0;

    const mesFin = fechaFin.getMonth() >= mesInicio ? fechaFin.getMonth() : 11;

    const optionsMeses = [];
    for (let mes = mesInicio; mes <= mesFin; mes++) {
      let fechaActual = new Date(anioSeleccionado, mes, 1);
      const nombreMes = fechaActual.toLocaleString("es", { month: "long" });
      optionsMeses.push({ value: mes + 1, label: nombreMes }); // Cambio aquí: usar mes + 1 como valor
    }

    setOptionsMes(optionsMeses);
    setSelectedMes(null);
  };
  const actualizarSemanasPorMes = (anioSeleccionado, mesSeleccionado) => {
    const primerDiaMes = new Date(anioSeleccionado, mesSeleccionado - 1, 1);
    const ultimoDiaMes = new Date(anioSeleccionado, mesSeleccionado, 0);

    let diaActual = new Date(primerDiaMes.getTime());
    let semanas = [];
    let semana = [];
    let numeroSemana = 0;

    if (diaActual < fechaInicio) {
      diaActual = new Date(fechaInicio.getTime());
    }

    if (diaActual.getDay() !== 1) {
      let diaInicioSemana = new Date(diaActual);
      diaInicioSemana.setDate(
        diaInicioSemana.getDate() - diaActual.getDay() + 1
      );

      for (
        let d = new Date(diaInicioSemana);
        d < diaActual;
        d.setDate(d.getDate() + 1)
      ) {
        semana.push(new Date(d));
      }
    }

    for (
      let d = new Date(diaActual);
      d <= ultimoDiaMes && d <= fechaFin;
      d.setDate(d.getDate() + 1)
    ) {
      semana.push(new Date(d));
      if (
        d.getDay() === 0 ||
        d.getDate() === ultimoDiaMes.getDate() ||
        d.getDate() === fechaFin.getDate()
      ) {
        numeroSemana++;
        semanas.push({ semana: numeroSemana, dias: [...semana] });
        semana = [];
      }
    }

    const semanasFormateadas = semanas.map((semana) => {
      const inicioSemana = semana.dias[0];
      const finSemana = semana.dias[semana.dias.length - 1];
      const opcionesFormato = { day: "2-digit", month: "long" };
      const label = `${inicioSemana.toLocaleDateString(
        "es-ES",
        opcionesFormato
      )} - ${finSemana.toLocaleDateString("es-ES", opcionesFormato)}`;
      const value = semana.semana;

      console.log(value);

      return { label, value };
    });

    setOptionsSemanas(semanasFormateadas);
  };

  const mandarSemana = (selectedSemana) => {
    const valorSemanaSeleccionada = selectedSemana;
    setDatosSelect({
      ...datosSelect,
      semana: valorSemanaSeleccionada,
    });
  };

  const mandarComercio = (selectedComercio) => {
    const valorComercioSeleccionado = selectedComercio;
    setDatosSelect({
      ...datosSelect,
      comercio: valorComercioSeleccionado,
    });
  };

  const [notificaciones, setNotificaciones] = useState({
    anios: [],
    meses: [],
    semanas: [],
    comercios: [],
  });

  useEffect(() => {
    setDatosSelect({
      anio: selectedAnio ? selectedAnio.value : 0, // Asegúrate de que el año sea un número
      mes: selectedMes ? selectedMes.value : "",
      semana: selectedSemana ? selectedSemana.value : "",
      comercio: selectedComercio ? selectedComercio.value : "",
    });
  }, [selectedAnio, selectedMes, selectedSemana, selectedComercio]);

  const handleEnviarDatos = () => {
    if (!selectedAnio || !selectedMes || !selectedSemana || !selectedComercio) {
      Swal.fire({
        title: "Error",
        text: "Por favor, selecciona todos los campos.",
        icon: "error",
        confirmButtonText: "Ok",
      });
      return;
    }

    enviarDatosAlContexto(datosSelect);

    Swal.fire({
      title: "¡Filtrado!",
      icon: "success",
      confirmButtonText: "Ok",
    });
  };

  const { darkMode } = useContext(DarkModeContext);

  const handleClick = () => {
    toggleDarkMode();
    show(!visible);
    enableScroll();
  };

  const [activeInicio, setActiveInicio] = useState(false);
  const [activeContabilidad, setActiveContabilidad] = useState(false);
  const [activeAnalisis, setActiveAnalisis] = useState(false);
  const [activeTicket, setActiveTicket] = useState(false);
  const [activeCalculadora, setActiveCalculadora] = useState(false);
  const [activeCalificar, setActiveCalificar] = useState(false);

  const activado = () => {
    if (activeInicio && darkMode) {
      return " d-flex btn-grid-active-dark centrado";
    } else if (activeInicio) {
      return " d-flex btn-grid-active centrado";
    } else if (darkMode) {
      return "d-flex btn-grid-dark centrado";
    } else {
      return " d-flex btn-grid centrado";
    }
  };

  const activadoContabilidad = () => {
    if (activeContabilidad && darkMode) {
      return " d-flex btn-grid-active-dark centrado";
    } else if (activeContabilidad) {
      return " d-flex btn-grid-active centrado";
    } else if (darkMode) {
      return "d-flex btn-grid-dark centrado";
    } else {
      return " d-flex btn-grid centrado";
    }
  };

  const activadoAnalisis = () => {
    if (activeAnalisis && darkMode) {
      return " d-flex btn-grid-active-dark centrado";
    } else if (activeAnalisis) {
      return " d-flex btn-grid-active centrado";
    } else if (darkMode) {
      return "d-flex btn-grid-dark centrado";
    } else {
      return " d-flex btn-grid centrado";
    }
  };

  const activadoTickets = () => {
    if (activeTicket && darkMode) {
      return " d-flex btn-grid-active-dark centrado";
    } else if (activeTicket) {
      return " d-flex btn-grid-active centrado";
    } else if (darkMode) {
      return "d-flex btn-grid-dark centrado";
    } else {
      return " d-flex btn-grid centrado";
    }
  };

  const activadoCalculadora = () => {
    if (activeCalculadora && darkMode) {
      return " d-flex btn-grid-active-dark centrado";
    } else if (activeCalculadora) {
      return " d-flex btn-grid-active centrado";
    } else if (darkMode) {
      return "d-flex btn-grid-dark centrado";
    } else {
      return " d-flex btn-grid centrado";
    }
  };

  const activadoCalificar = () => {
    if (activeCalificar && darkMode) {
      return " d-flex btn-grid-active-dark centrado";
    } else if (activeCalificar) {
      return " d-flex btn-grid-active centrado";
    } else if (darkMode) {
      return "d-flex btn-grid-dark centrado";
    } else {
      return " d-flex btn-grid centrado";
    }
  };

  const activadoIconoCampana = () => {
    if (visible1 && darkMode) {
      return " iconos-modales cursor-point text-white mx-3";
    } else if (visible1) {
      return " iconos-modales cursor-point text-dark mx-3";
    } else if (darkMode) {
      return "iconos-modales cursor-point  mx-3 color-verde";
    } else {
      return "iconos-modales cursor-point  mx-3 color-verde";
    }
  };

  const activadoIconoUser = () => {
    if (visible2 && darkMode) {
      return " iconos-modales cursor-point text-white mx-3";
    } else if (visible2) {
      return " iconos-modales cursor-point text-dark mx-3";
    } else if (darkMode) {
      return "iconos-modales cursor-point  mx-3 color-verde";
    } else {
      return "iconos-modales cursor-point  mx-3 color-verde";
    }
  };

  const reloadPage = () => {
    window.location.reload = "/";
  };

  const [modalShowCompleta, setModalShowCompleta] = React.useState(false);
  const [formData, setFormData] = useState({
    anterior: "",
    confirmar: "",
    nueva: "",
  });

  //Modal configuraciones
  function ModalConfiguraciones(props) {
    const { show, onHide } = props;
    const { control, handleSubmit, formState } = useForm();
    const { errors } = formState;

    const onSubmit = (data) => {
      setFormData(data);
      onHide();
    };

    return (
      <Modal
        {...props}
        show={show}
        onHide={onHide}
        centered
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
      >
        <Modal.Body
          className={
            darkMode
              ? " modal-content-dark text-white border-0"
              : "modal-content border-0 text-black "
          }
        >
          <section>
            <div className="d-flex justify-content-end">
              <FontAwesomeIcon
                onClick={onHide}
                className="fs-18 me-2"
                icon={faXmark}
              />
            </div>
          </section>
          <section>
            <div className="d-flex justify-content-center ">
              <h6 className="fs-20 lato-bold  ">Cambiar contraseña</h6>
            </div>
          </section>
          <div className="d-flex justify-content-center">
            <form className="py-5 " onSubmit={handleSubmit(onSubmit)}>
              <article>
                <div>
                  <label
                    className="lato-bold fs-16-a-14 mb-2"
                    htmlFor="anterior"
                  >
                    Ingresar contraseña anterior:
                  </label>
                </div>
                <div>
                  <Controller
                    name="anterior"
                    control={control}
                    rules={{ required: "Campo requerido" }}
                    render={({ field }) => (
                      <input
                        className="input-configuraciones border-0"
                        style={{ padding: "10px" }}
                        type="text"
                        {...field}
                      />
                    )}
                  />
                  <div className="text-danger">
                    {errors.anterior && (
                      <p className="fs-16 lato-bold">
                        {errors.anterior.message}
                      </p>
                    )}
                  </div>
                </div>
              </article>
              <article className="my-1">
                <div>
                  <label className="lato-bold fs-16-a-14 mb-2" htmlFor="nueva">
                    Ingresar contraseña nueva:
                  </label>
                </div>
                <div>
                  <Controller
                    name="nueva"
                    control={control}
                    rules={{ required: "Campo requerido" }}
                    render={({ field }) => (
                      <input
                        className="input-configuraciones border-0"
                        type="text"
                        style={{ padding: "10px" }}
                        {...field}
                      />
                    )}
                  />
                  <div className="text-danger ">
                    {errors.nueva && (
                      <p className="fs-16 lato-bold">{errors.nueva.message}</p>
                    )}
                  </div>
                </div>
              </article>
              <article className="my-1">
                <div>
                  <label
                    className="lato-bold fs-16-a-14 mb-2"
                    htmlFor="confirmar"
                  >
                    Ingresar contraseña nueva otra vez:
                  </label>
                </div>
                <div>
                  <Controller
                    name="confirmar"
                    control={control}
                    rules={{ required: "Campo requerido" }}
                    render={({ field }) => (
                      <input
                        className="input-configuraciones border-0"
                        type="text"
                        style={{ padding: "10px" }}
                        {...field}
                      />
                    )}
                  />
                  <div className="text-danger">
                    {errors.confirmar && (
                      <p className="fs-16 lato-bold">
                        {errors.confirmar.message}
                      </p>
                    )}
                  </div>
                </div>
              </article>
              <div className="d-flex justify-content-center my-5">
                <button
                  className={
                    darkMode
                      ? "btn-guardar-modal-configuraciones border-0 lato-bold text-dark "
                      : "btn-guardar-modal-configuraciones border-0 lato-bold text-white"
                  }
                  type="submit"
                >
                  Guardar
                </button>
              </div>
            </form>
          </div>
        </Modal.Body>
      </Modal>
    );
  }

  return (
    <div className="">
      <div
        className={
          darkMode
            ? "mobile-nav-menu-dark mt-3 mb-1 py-2"
            : "mobile-nav-menu py-2  mt-3 mb-1 "
        }
      >
        <div className="container d-flex justify-content-between ">
          <div className="ms-1 mt-2">
            <button
              className={
                darkMode
                  ? "mobile-nav-btn-fabars-dark"
                  : "mobile-nav-btn-fabars"
              }
              onClick={ocultar}
            >
              <FaBars size={25} />
            </button>
          </div>
          <div className="m-auto">
            <div>
              <img
                className="logo margen-right"
                src={darkMode ? logoClaro : logo}
                alt="logo"
              />
            </div>
          </div>
          <div>
            <div className=" centrado mt-1">
              <button
                className="btn-filtro border-0 text-white lato-bold fs-14"
                onClick={verModalFilter}
              >
                <FontAwesomeIcon className="me-1" icon={faFilter} />
                Filtros
              </button>
            </div>
          </div>
        </div>
        {visibleModal && (
          <div className="modalShadowFilter">
            <div className="">
              <div className={darkMode ? "modalbox-dark" : "modalbox "}>
                <button
                  className={
                    darkMode ? "border-0 close-dark" : "border-0 close"
                  }
                  onClick={verModalFilter}
                >
                  <FontAwesomeIcon
                    className={darkMode ? "text-white" : "text-black "}
                    icon={faXmark}
                  />
                </button>

                <h2 className="text-center mt-4 pb-2 lato-bold fs-16 ">
                  Filtros
                </h2>
                <div>
                  <form className="d-flex justify-content-around">
                    <article>
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 ms-3 "
                      >
                        Año
                      </label>
                      <Select
                        value={selectedAnio}
                        className="select__control_custom lato-bold"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="anio"
                        options={optionsAnios}
                        onChange={(selectedOption) => {
                          // Convertir el valor seleccionado a un número antes de establecer el estado
                          setSelectedAnio({
                            ...selectedOption,
                            value: Number(selectedOption.value),
                          });
                          actualizarMesesPorAnio(Number(selectedOption.value));
                        }}
                        styles={{
                          control: (base) => ({
                            ...base,
                            textAlign: "center",
                          }),
                        }}
                      />
                    </article>
                    <article>
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 ms-3"
                      >
                        Mes
                      </label>
                      <Select
                        value={selectedMes}
                        className="select__control_custom lato-bold"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="mes"
                        options={optionsMes}
                        onChange={(selectedOption) => {
                          setSelectedMes(selectedOption);
                          actualizarSemanasPorMes(
                            selectedAnio.value,
                            selectedOption.value
                          );
                        }}
                        styles={{
                          control: (base) => ({
                            ...base,
                            textAlign: "center",
                          }),
                        }}
                      />
                    </article>
                    <article>
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 ms-3"
                      >
                        Semanas
                      </label>
                      <Select
                        value={selectedSemana}
                        className="select__control_custom lato-bold"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="semanas"
                        options={optionsSemanas}
                        onChange={(selectedOption) => {
                          setSelectedSemana(selectedOption);
                          mandarSemana(selectedOption.value);
                        }}
                        styles={{
                          control: (base) => ({
                            ...base,
                            textAlign: "center",
                          }),
                        }}
                      />
                    </article>
                    <article>
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 ms-3"
                      >
                        Comercio
                      </label>
                      <Select
                        value={selectedComercio}
                        defaultInputValue={"Todos"}
                        className="select__control_custom lato-bold"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="comercio"
                        options={optionsComercio}
                        onChange={(selectedOption) => {
                          setSelectedComercio(selectedOption);
                          mandarComercio(selectedOption.value);
                        }}
                        styles={{
                          control: (base) => ({
                            ...base,
                            textAlign: "center",
                          }),
                        }}
                      />
                    </article>

                    <div className="mt-4 me-1">
                      <button
                        className="cursor-point ov-btn-slide-left border-0 lato-bold fs-16 text-white"
                        type="button"
                        onClick={handleEnviarDatos}
                      >
                        Aplicar
                      </button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        )}
        <nav className={visible ? "" : "navbar"}>
          <div className={darkMode ? "sidebar-dark" : "sidebar"}>
            <div className="d-flex justify-content-end ">
              <button
                className={
                  darkMode ? "mobile-nav-btn-cruz-dark" : "mobile-nav-btn-cruz"
                }
                onClick={aparecerScroll}
              >
                <FontAwesomeIcon className="fs-26" icon={faXmark} />
              </button>
            </div>
            <div className=" text-center">
              <img
                className="my-5 img-fluid logo-width"
                src={darkMode ? logoClaro : logo}
                alt="logo SOCO"
              />
              <div className="d-flex justify-content-center ">
                <div className="zoom">
                  <FontAwesomeIcon
                    onClick={handleClick}
                    className="iconos-modales cursor-point color-verde mx-3"
                    icon={darkMode ? faSun : faMoon}
                  />
                </div>

                <div className="zoom">
                  <FontAwesomeIcon
                    className={activadoIconoCampana()}
                    onClick={verModalNotificacion}
                    icon={faBell}
                  />
                </div>

                <div className="zoom">
                  <FontAwesomeIcon
                    className={activadoIconoUser()}
                    icon={faUser}
                    onClick={verModalCerrarSesion}
                  />
                </div>
              </div>
              {/* caja campana  */}
              {visible1 && (
                <div className="">
                  <div className="d-flex justify-content-center">
                    <img
                      className="img-fluid"
                      src={trianguloModal}
                      alt="triangulo modal"
                    />
                  </div>
                  <div className="d-flex justify-content-center">
                    <div
                      className={
                        darkMode
                          ? "caja-campana-cel-dark scroll-especifico-dark "
                          : "caja-campana-cel scroll-especifico"
                      }
                    >
                      <div className="container px-4">
                        <div className="d-flex flex-column justify-content-around">
                          <div>
                            <h6 className="fs-18 my-3">
                              <span className="color-verde fs-26">
                                <FontAwesomeIcon
                                  className="fs-8  color-verde"
                                  icon={faCircle}
                                />
                              </span>
                              <span className="ms-2">
                                Estimado aliado, nos complace informar el
                                lanzamiento del tablero de control en estado
                                beta
                              </span>
                            </h6>
                          </div>
                          <div>
                            <h6 className="fs-18 my-3">
                              <span className="fs-26">
                                {darkMode ? (
                                  <FontAwesomeIcon
                                    className="fs-8  color-blanco-items"
                                    icon={faCircle}
                                  />
                                ) : (
                                  <FontAwesomeIcon
                                    className="fs-8  color-negro-items"
                                    icon={faCircle}
                                  />
                                )}
                              </span>
                              <span className="ms-2">
                                De ahora en adelante, para realizar consultas
                                debe contactar directamente al departamento de
                                Liquidaciones a través del número: <br />
                                381 3545 650
                              </span>
                            </h6>
                          </div>{" "}
                          <div>
                            <h6 className="fs-18 my-3">
                              <span className="fs-26">
                                {darkMode ? (
                                  <FontAwesomeIcon
                                    className="fs-8  color-blanco-items"
                                    icon={faCircle}
                                  />
                                ) : (
                                  <FontAwesomeIcon
                                    className="fs-8  color-negro-items"
                                    icon={faCircle}
                                  />
                                )}
                              </span>
                              <span className="ms-2">
                                Informamos que el error en donde no...
                              </span>
                            </h6>
                          </div>
                          <div>
                            <h6 className="fs-18 my-3">
                              <span className="color-verde fs-26">
                                {darkMode ? (
                                  <FontAwesomeIcon
                                    className="fs-8  color-blanco-items"
                                    icon={faCircle}
                                  />
                                ) : (
                                  <FontAwesomeIcon
                                    className="fs-8  color-negro-items"
                                    icon={faCircle}
                                  />
                                )}
                              </span>
                              <span className="ms-2">
                                Estimado aliado, nos complace informar el
                                lanzamiento del tablero de control en estado
                                beta
                              </span>
                            </h6>
                          </div>
                          <div>
                            <h6 className="fs-18 my-3">
                              <span className="fs-26">
                                {darkMode ? (
                                  <FontAwesomeIcon
                                    className="fs-8  color-blanco-items"
                                    icon={faCircle}
                                  />
                                ) : (
                                  <FontAwesomeIcon
                                    className="fs-8  color-negro-items"
                                    icon={faCircle}
                                  />
                                )}
                              </span>
                              <span className="ms-2">
                                De ahora en adelante, para realizar consultas
                                debe contactar directamente al departamento de
                                Liquidaciones a través del número: <br />
                                381 3545 650
                              </span>
                            </h6>
                          </div>{" "}
                          <div>
                            <h6 className="fs-18 my-3">
                              <span className="fs-26">
                                {darkMode ? (
                                  <FontAwesomeIcon
                                    className="fs-8  color-blanco-items"
                                    icon={faCircle}
                                  />
                                ) : (
                                  <FontAwesomeIcon
                                    className="fs-8  color-negro-items"
                                    icon={faCircle}
                                  />
                                )}
                              </span>
                              <span className="ms-2">
                                Informamos que el error en donde no...
                              </span>
                            </h6>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              )}
              {/* caja cerrar sesion  */}
              {visible2 && (
                <div className=" container">
                  <div className="d-flex justify-content-center">
                    <div className="mx-3"></div>
                    <div className="mx-5"></div>
                    <div className="mx-3">
                      <img
                        className="img-fluid"
                        src={trianguloModal}
                        alt="triangulo modal"
                      />
                    </div>
                  </div>
                  <div className="d-flex justify-content-center">
                    <div
                      className={
                        darkMode
                          ? "caja-cerrar-sesion-dark centrado"
                          : "caja-cerrar-sesion centrado"
                      }
                    >
                      <div className="container">
                        <div className="d-flex flex-column justify-content-around">
                          <div>
                            <h6
                              className={
                                darkMode
                                  ? "fs-18 lato-bold text-white my-3"
                                  : "fs-18 lato-bold my-3"
                              }
                            >
                              Zoco SAS
                            </h6>
                            <div>
                              {/* <NavLink
                                  onClick={aparecerScroll}
                                  end
                                  to="/"
                                  className=" border-0"
                                >
                                  <div
                                    className={
                                      darkMode
                                        ? "d-flex btn-nav-configuracion-dark  centrado"
                                        : "d-flex btn-nav-configuracion centrado"
                                    }
                                  >
                                    <div className="ms-3">
                                      <FontAwesomeIcon icon={faGear} />
                                      <span className="ms-2 lato-bold fs-12">
                                        Configuraciones
                                      </span>
                                    </div>
                                  </div>
                                </NavLink> */}
                              <div className="centrado my-3">
                                <Button
                                  className={
                                    darkMode
                                      ? "d-flex btn-nav-configuracion-dark  centrado border-0"
                                      : "d-flex btn-nav-configuracion centrado  border-0"
                                  }
                                  onClick={() => setModalShowCompleta(true)}
                                >
                                  <FontAwesomeIcon className="" icon={faGear} />
                                  <span className="ms-2  lato-bold fs-14">
                                    Configuraciones
                                  </span>
                                </Button>
                                <ModalConfiguraciones
                                  show={modalShowCompleta}
                                  onHide={() => setModalShowCompleta(false)}
                                />
                              </div>

                              <div className="centrado my-3">
                                <NavLink
                                  end
                                  to="/"
                                  onClick={reloadPage}
                                  className=" border-0"
                                >
                                  <div
                                    className={
                                      darkMode
                                        ? "d-flex btn-nav-cerrar-sesion-dark centrado "
                                        : "d-flex btn-nav-cerrar-sesion centrado"
                                    }
                                  >
                                    <div className="ms-3">
                                      <FontAwesomeIcon
                                        icon={faRightFromBracket}
                                      />
                                      <span className="ms-2 lato-bold fs-14">
                                        Cerrar sesión
                                      </span>
                                    </div>
                                  </div>
                                </NavLink>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              )}
            </div>
            <div className="mt-4">
              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/inicio"
                  className=" border-0"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activado()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faHouse} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16"> Inicio</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>

              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/contabilidad"
                  className=" border-0"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activadoContabilidad()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faFileInvoiceDollar} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16"> Contabilidad</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>

              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/analisis"
                  className=" border-0"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activadoAnalisis()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faMagnifyingGlassChart} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16">Análisis</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>

              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/tickets"
                  className=" border-0"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activadoTickets()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faReceipt} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16">Cupones</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>
              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/calculadora"
                  className=" border-0"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activadoCalculadora()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faCalculator} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16">Calculadora</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>

              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/calificar"
                  className=" border-0"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activadoCalificar()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faStar} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16">Calificar</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>
              <div className="centrado my-2" onClick={aparecerScroll}>
                <a
                  href="https://api.whatsapp.com/send/?phone=543813545650&text=Buenos%2Fas+d%C3%ADas%2Ftardes%2Cmi+CUIT+es%3A++tengo+una+consulta+sobre&type=phone_number&app_absent=0"
                  target="_blank"
                  rel="noreferrer"
                  className=" border-0 "
                  style={{ width: "160px" }}
                >
                  <div
                    className={
                      darkMode ? " d-flex btn-grid-dark " : " d-flex btn-grid "
                    }
                  >
                    <div className="icono">
                      <FontAwesomeIcon icon={faWhatsapp} />
                    </div>
                    <div className="texto">
                      <span className="lato-bold fs-16">Whatsapp</span>
                    </div>
                  </div>
                </a>
              </div>
            </div>
          </div>
        </nav>
      </div>
    </div>
  );
}

export default NavbarReact;
