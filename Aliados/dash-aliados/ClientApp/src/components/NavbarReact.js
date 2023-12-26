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

const optionsAnios = [
  { value: "2023", label: "2023" },
  { value: "2022", label: "2022" },
  { value: "2021", label: "2021" },
];

const optionsMes = [
  { value: "enero", label: "Enero" },
  { value: "febrero", label: "Febrero" },
  { value: "marzo", label: "Marzo" },
  { value: "abril", label: "Abril" },
  { value: "mayo", label: "Mayo" },
  { value: "junio", label: "Junio" },
  { value: "julio", label: "Julio" },
  { value: "agosto", label: "Agosto" },
  { value: "septiembre", label: "Septiembre" },
  { value: "octubre", label: "Octubre" },
  { value: "noviembre", label: "Noviembre" },
  { value: "diciembre", label: "Diciembre" },
];

const optionsComercio = [
  { value: "Todos", label: "Todos" },
  { value: "craft", label: "Craft" },
  { value: "la Bandeña", label: "La Bandeña" },
  { value: "casapan", label: "Casapan" },
];

const optionsSemanas = [
  { value: "semana 1-7", label: "1-7" },
  { value: "semana 7-14", label: "7-14" },
  { value: "semana 14-21", label: "14-21" },
  { value: "semana 21-28", label: "21-28" },
  { value: "semana 28-31", label: "28-31" },
];

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
  console.log(
    "🚀 ~ file: BienvenidoPanel.js:43 ~ BienvenidoPanel ~ datoCapturados:",
    datoCapturados
  );
  const [isSearchable, setIsSearchable] = useState(true);
  console.log(
    "🚀 ~ file: NavbarReact.js:117 ~ NavbarReact ~ setIsSearchable:",
    setIsSearchable
  );
  const [selectedAnio, setSelectedAnio] = useState(null);
  const [selectedMes, setSelectedMes] = useState(null);
  const [selectedComercio, setSelectedComercio] = useState(null);
  const [selectedSemana, setSelectedSemana] = useState(null);

  const handleEnviarDatos = () => {
    const data = {
      anio: selectedAnio?.value,
      mes: selectedMes?.value,
      comercio: selectedComercio?.value,
      semana: selectedSemana?.value,
    };
    setDatoCapturados(data);
    verModalFilter();
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
                  <form className=" ">
                    <article className="py-2 text-center">
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 mb-2 ms-2 d-flex"
                      >
                        Año
                      </label>

                      <Select
                        value={selectedAnio}
                        defaultInputValue="2023"
                        className="select__control_custom_filter"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="anio"
                        options={optionsAnios}
                        onChange={(selectedOption) =>
                          setSelectedAnio(selectedOption)
                        }
                      />
                    </article>
                    <article className="py-2 text-center">
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 mb-2 d-flex ms-2"
                      >
                        Mes
                      </label>
                      <Select
                        value={selectedMes}
                        defaultInputValue="octubre"
                        className="select__control_custom_filter"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="mes"
                        options={optionsMes}
                        onChange={(selectedOption) =>
                          setSelectedMes(selectedOption)
                        }
                      />
                    </article>
                    <article className="py-2 text-center">
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 mb-2 d-flex ms-2"
                      >
                        Comercio
                      </label>
                      <Select
                        value={selectedComercio}
                        defaultInputValue="Todos"
                        className="select__control_custom_filter"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="comercio"
                        options={optionsComercio}
                        onChange={(selectedOption) =>
                          setSelectedComercio(selectedOption)
                        }
                      />
                    </article>
                    <article className="py-2  text-center">
                      <label
                        htmlFor="exampleFormControlInput1"
                        className="lato-bold fs-16 mb-2 d-flex ms-2"
                      >
                        Semanas
                      </label>
                      <Select
                        value={selectedSemana}
                        defaultInputValue="semana 1-7"
                        className="select__control_custom_filter"
                        classNamePrefix="select"
                        isSearchable={isSearchable}
                        name="semanas"
                        options={optionsSemanas}
                        onChange={(selectedOption) =>
                          setSelectedSemana(selectedOption)
                        }
                      />
                    </article>
                    <div className="my-5 me-1 d-flex justify-content-center">
                      <button
                        className="cursor-point btn-enviar-filtros-modal border-0 lato-bold fs-16 text-white"
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
