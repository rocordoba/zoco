import "./SidebarReact.css";
import {
  faBell,
  faCalculator,
  faCircle,
  faFileInvoiceDollar,
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
import { NavLink} from "react-router-dom";
import qr from "../assets/img/qr.png";
import qrClaro from "../assets/img/qr-blanco.png";
import logo from "../assets/img/logo.png";
import logoClaro from "../assets/img/logo-modo-oscuro.png";
import { faWhatsapp } from "@fortawesome/free-brands-svg-icons";
import trianguloModal from "../assets/img/triangulomodales.png";
import trianguloModalDark from "../assets/img/triangulomodalesdark.png";
import { DarkModeContext } from "../context/DarkModeContext";
import { Button, Modal } from "react-bootstrap";
import { useForm, Controller } from "react-hook-form";
import { useRef } from "react";
import { useEffect } from "react";

const SidebarReact = () => {
  const [visible1, setVisible1] = useState(false);

  const [visible2, setVisible2] = useState(false);

  const verModalNotificacion = () => {
    setVisible1(!visible1);
    setVisible2(false);
  };

  const verModalCerrarSesion = () => {
    setVisible2(!visible2);
    setVisible1(false);
  };

  const [activeInicio, setActiveInicio] = useState(false);
  const [activeContabilidad, setActiveContabilidad] = useState(false);
  const [activeAnalisis, setActiveAnalisis] = useState(false);
  const [activeTicket, setActiveTicket] = useState(false);
  const [activeCalculadora, setActiveCalculadora] = useState(false);
  const [activeCalificar, setActiveCalificar] = useState(false);

  const ocultarModalesInicio = () => {
    setActiveInicio(true);
    setActiveContabilidad(false);
    setActiveAnalisis(false);
    setActiveTicket(false);
    setActiveCalculadora(false);
    setActiveCalificar(false);
  };

  const ocultarModalesContabilidad = () => {
    setVisible2(false);
    setVisible1(false);
    setActiveInicio(false);
    setActiveContabilidad(true);
    setActiveAnalisis(false);
    setActiveTicket(false);
    setActiveCalculadora(false);
    setActiveCalificar(false);
  };

  const ocultarModalesAnalisis = () => {
    setVisible2(false);
    setVisible1(false);
    setActiveInicio(false);
    setActiveContabilidad(false);
    setActiveAnalisis(true);
    setActiveTicket(false);
    setActiveCalculadora(false);
    setActiveCalificar(false);
  };

  const ocultarModalesTickets = () => {
    setVisible2(false);
    setVisible1(false);
    setActiveInicio(false);
    setActiveContabilidad(false);
    setActiveAnalisis(false);
    setActiveTicket(true);
    setActiveCalculadora(false);
    setActiveCalificar(false);
  };

  const ocultarModalesCalculadora = () => {
    setVisible2(false);
    setVisible1(false);
    setActiveInicio(false);
    setActiveContabilidad(false);
    setActiveAnalisis(false);
    setActiveTicket(false);
    setActiveCalculadora(true);
    setActiveCalificar(false);
  };

  const ocultarModalesCalificar = () => {
    setVisible2(false);
    setVisible1(false);
    setActiveInicio(false);
    setActiveContabilidad(false);
    setActiveAnalisis(false);
    setActiveTicket(false);
    setActiveCalculadora(false);
    setActiveCalificar(true);
  };

  const ocultarModales = () => {
    setVisible2(false);
    setVisible1(false);
    setActiveInicio(false);
    setActiveContabilidad(false);
    setActiveAnalisis(false);
    setActiveTicket(false);
    setActiveCalculadora(false);
    setActiveCalificar(false);
  };

  const reloadPage = () => {
    window.location.reload = "/";
  };

  //switch claro/oscuro
  const { toggleDarkMode } = useContext(DarkModeContext);

  const handleClick = () => {
    toggleDarkMode();
  };

  // claro/oscuro
  const { darkMode } = useContext(DarkModeContext);

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

  const [modalShowCompleta, setModalShowCompleta] = React.useState(false);

  const [formData, setFormData] = useState({
    anterior: "",
    confirmar: "",
    nueva: "",
  });
  console.log("🚀 ~ file: SidebarReact.js:248 ~ SidebarReact ~ formData:", formData)

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
              ? " modal-content-dark text-white "
              : "modal-content text-black "
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
              <div className="d-flex justify-content-center mt-5">
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

  //click fuera del modal
  const modalCampanaRef = useRef(null);
  const modalCerrarSesionRef = useRef(null);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (
        (modalCampanaRef.current &&
          !modalCampanaRef.current.contains(event.target)) ||
        (modalCerrarSesionRef.current &&
          !modalCerrarSesionRef.current.contains(event.target))
      ) {
        setVisible1(false);
        setVisible2(false);
      }
    };

    document.addEventListener("mousedown", handleClickOutside);

    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, [modalCampanaRef, modalCerrarSesionRef]);

  return (
    <>
      <section className={darkMode ? " sidebar-dark" : `sidebar `}>
        <div className="py-5 text-center">
          <img
            className="my-4 img-fluid"
            src={darkMode ? logoClaro : logo}
            alt="logo"
            width="140"
            height="40"
          />
          <div className="d-flex justify-content-center mt-3">
            <div className="zoom">
              <FontAwesomeIcon
                onClick={handleClick}
                className="iconos-modales color-verde mx-3"
                icon={darkMode ? faSun : faMoon}
              />
            </div>

            <div className="zoom" onClick={() => {verModalNotificacion(); setVisible2(false);}}>
              <FontAwesomeIcon
                className={activadoIconoCampana()}
                
                icon={faBell}
              />
            </div>
            <div className="zoom" onClick={() => {verModalCerrarSesion(); setVisible1(false);}}>
              <FontAwesomeIcon
                className={activadoIconoUser()}
                icon={faUser}
                />
            </div>
          </div>
          {/* caja campana  */}
          {visible1 && (
            <div className="" ref={modalCampanaRef}>
              <div className="d-flex justify-content-center">
                {darkMode ? (
                  <div>
                    <img
                      className="img-fluid"
                      src={trianguloModalDark}
                      alt="triangulo modal"
                    />
                  </div>
                ) : (
                  <div>
                    <img
                      className="img-fluid"
                      src={trianguloModal}
                      alt="triangulo modal"
                    />
                  </div>
                )}
              </div>
              <div className="d-flex justify-content-center ">
                <div
                  className={
                    darkMode
                      ? "caja-campana-dark scroll-especifico-dark"
                      : "caja-campana scroll-especifico"
                  }
                >
                  <div className="container px-4">
                    <div className="d-flex flex-column justify-content-around">
                      <div>
                        <h6 className="fs-16 my-3">
                          <span className="color-verde me-2">
                            <FontAwesomeIcon
                              className="fs-8  color-verde"
                              icon={faCircle}
                            />
                          </span>
                          Estimado aliado, nos complace informar el lanzamiento
                          del tablero de control en estado beta
                        </h6>
                      </div>
                      <div>
                        <h6 className="fs-16 my-3">
                          <span className=" me-2">
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
                          De ahora en adelante, para realizar consultas debe
                          contactar directamente al departamento de
                          Liquidaciones a través del número: <br />
                          381 3545 650
                        </h6>
                      </div>{" "}
                      <div>
                        <h6 className="fs-16 my-3">
                          <span className=" me-2">
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
                          De ahora en adelante, para realizar consultas debe
                          contactar directamente al departamento de
                          Liquidaciones a través del número: <br />
                          381 3545 650
                        </h6>
                      </div>{" "}
                      <div>
                        <h6 className="fs-16 my-3">
                          <span className=" me-2">
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
                          De ahora en adelante, para realizar consultas debe
                          contactar directamente al departamento de
                          Liquidaciones a través del número: <br />
                          381 3545 650
                        </h6>
                      </div>{" "}
                      <div>
                        <h6 className="fs-16 my-3">
                          <span className="me-2">
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
                          Informamos que el error en donde no...
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
            <div className=" container" ref={modalCerrarSesionRef}>
              <div className="d-flex justify-content-center">
                <div className="mx-3"></div>
                <div className="mx-5"></div>
                <div className="mx-3">
                  {darkMode ? (
                    <div>
                      <img
                        className="img-fluid"
                        src={trianguloModalDark}
                        alt="triangulo modal"
                      />
                    </div>
                  ) : (
                    <div>
                      <img
                        className="img-fluid"
                        src={trianguloModal}
                        alt="triangulo modal"
                      />
                    </div>
                  )}
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
                    <div className="">
                      <div className="py-4">
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
                                  <FontAwesomeIcon icon={faRightFromBracket} />
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
        <div className="centrado my-2">
          <NavLink
            end
            to="/aliados/inicio"
            className=" border-0"
            onClick={ocultarModalesInicio}
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
            onClick={ocultarModalesContabilidad}
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
            to="/aliados/calculadora"
            className=" border-0"
            onClick={ocultarModalesCalculadora}
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
            to="/aliados/analisis"
            className=" border-0"
            onClick={ocultarModalesAnalisis}
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
            onClick={ocultarModalesTickets}
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
            to="/aliados/calificar"
            className=" border-0"
            onClick={ocultarModalesCalificar}
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

        <div
          className={
            visible1 === true || visible2 === true
              ? " text-center"
              : "py-5 text-center"
          }
        >
          <div className="centrado my-2" onClick={ocultarModales}>
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
          <img
            className="img-fluid img-qr mt-3 pb-1"
            src={darkMode ? qrClaro : qr}
            alt="codigo qr"
          />
        </div>
      </section>
    </>
  );
};

export default SidebarReact;
