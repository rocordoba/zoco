import "./NuevoNavReact.css";
import React, { useContext, useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import Offcanvas from "react-bootstrap/Offcanvas";
import { DarkModeContext } from "../context/DarkModeContext";
import { FaBars } from "react-icons/fa";
import logo from "../assets/img/logo.png";
import logoClaro from "../assets/img/logo-modo-oscuro.png";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faBell,
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
import { NavLink } from "react-router-dom";
import Select from "react-select";
import trianguloModal from "../assets/img/triangulomodales.png";
import { faWhatsapp } from "@fortawesome/free-brands-svg-icons";

import ModalConfiguracionesCel from "./ModalConfiguracionesCel";
import { DatosInicioContext } from "../context/DatosInicioContext";
import Swal from "sweetalert2";
import NotificacionIndicador from "./NotificacionIndicador";

const NuevoNavReact = ({ name, ...props }) => {
  //states del sidebar
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);

  const toggleShow = () => setShow((s) => !s);

  useEffect(() => {
    const handleResize = () => {
      if (window.innerWidth >= 768) {
        setShow(false);
      }
    };

    window.addEventListener("resize", handleResize);

    return () => {
      window.removeEventListener("resize", handleResize);
    };
  }, []);

  const { darkMode } = useContext(DarkModeContext);
  const [datoCapturados, setDatoCapturados] = useState({});
  const [isSearchable, setIsSearchable] = useState(true);
  const [selectedAnio, setSelectedAnio] = useState(null);
  const [selectedMes, setSelectedMes] = useState(null);
  const [selectedComercio, setSelectedComercio] = useState(null);
  const [selectedSemana, setSelectedSemana] = useState(null);

  const [visibleModal, setVisibleModal] = useState(false);
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

  const enviarDatosAlContexto = (datos) => {
    actualizarDatos(datos);
  };

  const procesarDatos = (data) => {
    //   console.log("Respuesta de la API:", data);

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
    const añoActual = new Date().getFullYear();
    const mesActual = new Date().toLocaleString("es", { month: "long" });

    // Función para obtener el número de la semana
    const obtenerNumeroSemana = (fecha) => {
      const inicioDeAño = new Date(fecha.getFullYear(), 0, 1);
      const diff = fecha - inicioDeAño;
      const semana = Math.ceil(
        (diff / 86400000 + inicioDeAño.getDay() + 1) / 7
      );
      return semana;
    };

    // Obtener la semana actual
    const semanaActual = obtenerNumeroSemana(new Date());
    setOptionsComercio(optionsComercio);
    setOptionsAnios(optionsAnios);
    setOptionsMes(optionsMeses);
    setOptionsSemanas(optionsSemanas);
    setFechaInicio(fechaInicio);
    setFechaFin(fechaFin);
    setSelectedAnio({
      value: añoActual.toString(),
      label: añoActual.toString(),
    });
    setSelectedMes({ value: mesActual.toLowerCase(), label: mesActual });
    setSelectedSemana({
      value: semanaActual.toString(),
      label: semanaActual.toString(),
    });
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
          //   console.log("Datos recibidos de la API:", data);
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
    let numeroSemanaDelMes = 0;

    // Ajustar el primer día de la semana al lunes más cercano
    if (diaActual.getDay() !== 1) {
      diaActual.setDate(diaActual.getDate() - diaActual.getDay() + 1);
    }

    // Iterar a través de los días del mes
    for (
      let d = new Date(diaActual);
      d <= ultimoDiaMes;
      d.setDate(d.getDate() + 1)
    ) {
      if (d.getDate() === 1 || d.getDay() === 1) {
        numeroSemanaDelMes++;
      }

      // Detener el proceso si se alcanza la semana 5
      if (numeroSemanaDelMes > 5) {
        break;
      }

      semana.push(new Date(d));
      if (d.getDay() === 0 || d.getDate() === ultimoDiaMes.getDate()) {
        semanas.push({ numeroSemanaDelMes, dias: [...semana] });
        semana = [];
      }
    }

    // Filtrar las semanas que caen dentro del rango de fechaInicio y fechaFin
    const semanasFiltradas = semanas.filter((semana) => {
      const inicioSemana = semana.dias[0];
      const finSemana = semana.dias[semana.dias.length - 1];
      return (
        (!fechaInicio || finSemana >= fechaInicio) &&
        (!fechaFin || inicioSemana <= fechaFin)
      );
    });

    // Formatear las semanas para el uso en el front-end
    const semanasFormateadas = semanasFiltradas.map((semana) => {
      const label = `Semana ${semana.numeroSemanaDelMes}`;
      const value = semana.numeroSemanaDelMes;

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
  };

  const verModalFilter = () => {
    setVisible2(false);
    setVisible1(false);
    setVisibleModal(!visibleModal);
  };

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

  const { toggleDarkMode } = useContext(DarkModeContext);

  const aparecerScroll = () => {
    setShow(false);
  };

  //css de los btn navlink
  const [activeInicio, setActiveInicio] = useState(false);

  const [activeContabilidad, setActiveContabilidad] = useState(false);
  const [activeAnalisis, setActiveAnalisis] = useState(false);

  const [activeTicket, setActiveTicket] = useState(false);

  const [activeCalculadora, setActiveCalculadora] = useState(false);

  const [activeCalificar, setActiveCalificar] = useState(false);

  // const [activeTerminal, setActiveTerminal] = useState(false)

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

  const handleClick = () => {
    toggleDarkMode();
    setVisible2(false);
    setVisible1(false);
  };

  const reloadPage = () => {
    window.location.reload = "/";
  };

  const [modalShowCompleta, setModalShowCompleta] = React.useState(false);
  const [mostrarOffcanvas, setMostrarOffcanvas] = useState(false);

  const cerrarOffcanvas = () => {
    setMostrarOffcanvas(false);
  };

  const otroEvento = () => {
    setVisible1(false);
    setVisible2(false);
  };

  const handleClose2 = () => {
    cerrarOffcanvas();
    otroEvento();
  };

  const [notificaciones, setNotificaciones] = useState([]);

  useEffect(() => {
    const fetchNoticias = async () => {
      try {
        const response = await fetch("/api/notificacion/noticias");
        const data = await response.json();
        setNotificaciones(data);
      } catch (error) {
        console.error("Error al cargar noticias:", error);
      }
    };

    fetchNoticias();
  }, []);

  const [hayNotificacionesNoVistas, setHayNotificacionesNoVistas] =
    useState(true);
  const [usuarioRol, setUsuarioRol] = useState();

  useEffect(() => {
    const verificarToken = async () => {
      const token = sessionStorage.getItem("token");

      try {
        const response = await fetch("/api/token/token", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({ Token: token }),
        });

        if (!response.ok) {
          throw new Error("Error en la respuesta del servidor");
        }

        const datosRecibido = await response.json();
        setUsuarioRol(datosRecibido);
        // Aquí puedes hacer algo con el rol
        // Por ejemplo, guardarlo en el estado o realizar alguna lógica basada en el rol
      } catch (error) {
        console.error("Error al validar el token", error);
      }
    };

    verificarToken();
  }, [usuarioRol]);

  // funcion para borrar el token y cerrar sesion
  const cerrarSesion = async () => {
    const token = sessionStorage.getItem("token");
    if (!token) {
      console.error("No hay token en el almacenamiento de la sesión");
      return;
    }

    try {
      const response = await fetch("/api/acceso/logout", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ Token: token }),
      });

      if (response.ok) {
        console.log("Sesión cerrada correctamente");
        // Aquí puedes redireccionar al usuario o realizar otras acciones necesarias después de cerrar sesión
        sessionStorage.removeItem("token"); // Eliminar el token del sessionStorage
        // Redireccionar al usuario, por ejemplo a la página de inicio de sesión
        window.location.href = "/";
      } else {
        console.error("Error al cerrar sesión:", await response.text());
      }
    } catch (error) {
      console.error(
        "Error al realizar la solicitud de cierre de sesión:",
        error
      );
    }
  };

  return (
    <section className="container">
      <Offcanvas
        className={darkMode ? "bg-dark" : "bg-white"}
        show={mostrarOffcanvas}
        onHide={handleClose2}
        {...props}
      >
        <Offcanvas.Header closeButton>
          <Offcanvas.Title></Offcanvas.Title>
        </Offcanvas.Header>
        <Offcanvas.Body>
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

              <div className="zoom" style={{ position: "relative" }}>
                {hayNotificacionesNoVistas && (
                  <NotificacionIndicador count={"!"} />
                )}
                <FontAwesomeIcon
                  onClick={() => {
                    verModalNotificacion();
                    setVisible2(false);
                    setHayNotificacionesNoVistas(false);
                  }}
                  className={activadoIconoCampana()}
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
                        {notificaciones.map((notificacion, index) => (
                          <div key={index}>
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
                              {notificacion.noticia1}
                            </h6>
                          </div>
                        ))}
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
                                <span className="ms-2  lato-bold fs-10">
                                  Cambiar contraseña
                                </span>
                              </Button>
                              <ModalConfiguracionesCel
                                show={modalShowCompleta}
                                onHide={() => setModalShowCompleta(false)}
                              />
                            </div>

                            <div className="centrado my-3">
                              {/* Botón para cerrar sesión */}
                              <button
                                className={
                                  darkMode
                                    ? "d-flex btn-nav-cerrar-sesion-dark centrado border-0 "
                                    : "d-flex btn-nav-cerrar-sesion centrado border-0"
                                }
                                onClick={cerrarSesion}
                              >
                                <div>
                                  <div className="ms-3">
                                    <FontAwesomeIcon
                                      icon={faRightFromBracket}
                                    />
                                    <span className="ms-2 lato-bold fs-10">
                                      Cerrar sesión
                                    </span>
                                  </div>
                                </div>
                              </button>
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
          {/* botones navlink */}
          {usuarioRol === 0 ? (
            <>
              <div className="mt-4">
                <div className="centrado my-2">
                  <NavLink
                    end
                    to="/aliados/inicio"
                    className=" border-0 text-decoration-none"
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
                    className=" border-0 text-decoration-none"
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
                {/* <div className="centrado my-2">
              <NavLink
                end
                to="/aliados/calculadora"
                className=" border-0 text-decoration-none"
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
            </div> */}
                <div className="centrado my-2">
                  <NavLink
                    end
                    to="/aliados/analisis"
                    className=" border-0 text-decoration-none"
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
                    to="/aliados/cupones"
                    className=" border-0 text-decoration-none"
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
                    to="/aliados/calificar"
                    className=" border-0 text-decoration-none"
                    onClick={aparecerScroll}
                  >
                    <div style={{ width: "160px" }}>
                      <div className={activadoCalculadora()}>
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
                    className=" border-0 text-decoration-none"
                    style={{ width: "160px" }}
                  >
                    <div
                      className={
                        darkMode
                          ? " d-flex btn-grid-dark "
                          : " d-flex btn-grid "
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
            </>
          ) : (
            <>
              <div className="centrado my-2">
                <NavLink
                  end
                  to="/aliados/calificar"
                  className=" border-0 text-decoration-none"
                  onClick={aparecerScroll}
                >
                  <div style={{ width: "160px" }}>
                    <div className={activadoCalculadora()}>
                      <div className="icono">
                        <FontAwesomeIcon icon={faStar} />
                      </div>
                      <div className="texto">
                        <span className="lato-bold fs-16">Prueba rol</span>
                      </div>
                    </div>
                  </div>
                </NavLink>
              </div>
            </>
          )}
        </Offcanvas.Body>
      </Offcanvas>
      <section
        className={
          darkMode ? " mobile-nav-menu-dark py-4" : "mobile-nav-menu py-4"
        }
      >
        <div className="container d-flex justify-content-between centrado">
          <div className="">
            <Button
              variant="primary"
              onClick={() => setMostrarOffcanvas(true)}
              className={
                darkMode
                  ? "mobile-nav-btn-fabars-dark"
                  : "mobile-nav-btn-fabars"
              }
            >
              <FaBars size={25} />
            </Button>
          </div>
          <div className="">
            <div>
              <img
                className="logo img-fluid "
                src={darkMode ? logoClaro : logo}
                alt="logo"
              />
            </div>
          </div>
          <div>
            <div className="  ">
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
                <button className="border-0 close" onClick={verModalFilter}>
                  <FontAwesomeIcon icon={faXmark} />
                </button>
                <h2 className="text-center mt-4 pb-2 lato-bold fs-16 ">
                  Filtros
                </h2>
                <div>
                  <form className=" ">
                    <article className="">
                      <div className="d-flex justify-content-start">
                        <label
                          htmlFor="exampleFormControlInput1"
                          className="lato-bold fs-16 ms-3 "
                        >
                          Año
                        </label>
                      </div>
                      <div>
                        <Select
                          value={selectedAnio}
                          className="lato-bold"
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
                            actualizarMesesPorAnio(
                              Number(selectedOption.value)
                            );
                          }}
                          styles={{
                            control: (base) => ({
                              ...base,
                              textAlign: "center",
                            }),
                          }}
                        />
                      </div>
                    </article>
                    <article>
                      <div className="d-flex justify-content-start">
                        <label
                          htmlFor="exampleFormControlInput1"
                          className="lato-bold fs-16 ms-3"
                        >
                          Mes
                        </label>
                      </div>
                      <Select
                        value={selectedMes}
                        className="lato-bold"
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
                      <div className="d-flex justify-content-start">
                        <label
                          htmlFor="exampleFormControlInput1"
                          className="lato-bold fs-16 ms-3"
                        >
                          Semanas
                        </label>
                      </div>
                      <Select
                        value={selectedSemana}
                        className=" lato-bold"
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
                      <div className="d-flex justify-content-start">
                        <label
                          htmlFor="exampleFormControlInput1"
                          className="lato-bold fs-16 ms-3"
                        >
                          Comercio
                        </label>
                      </div>
                      <Select
                        value={selectedComercio}
                        defaultInputValue={"Todos"}
                        className=" lato-bold"
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
      </section>
    </section>
  );
};

export default NuevoNavReact;
