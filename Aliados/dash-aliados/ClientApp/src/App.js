import React, { useContext, useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./custom.css";
import { DarkModeContext } from "./context/DarkModeContext";
import Inicio from "./views/aliados/Inicio";
import Contabilidad from "./views/aliados/Contabilidad";
import Analisis from "./views/aliados/Analisis";
import Tickets from "./views/aliados/Tickets";
import Calculadora from "./views/aliados/Calculadora";
import Calificar from "./views/aliados/Calificar";
import Login from "./views/aliados/Login";
import SidebarReact from "./components/SidebarReact";
import ScrollToTop from "./components/ScrollToTop";
import NuevoNavReact from "./components/NuevoNavReact";
import { DatosInicioContext } from "./context/DatosInicioContext";

function App() {
  const { darkMode } = useContext(DarkModeContext);
  const [navVisible, showNavbar] = useState(false);
  const { califico, setCalifico } =
    useContext(DatosInicioContext);
  return (
    <div className={darkMode ? "container-dark" : "container-light bg-gris"}>
      <BrowserRouter>
        <div className="App">
          {window.location.pathname === "/" ? (
            <div
              className={
                darkMode ? "container-dark" : "container-light bg-gris"
              }
            >
              <Login
              />
            </div>
          ) : (
            <div>
              <div className="d-xl-none d-block my-3 ">
                <NuevoNavReact />
              </div>
              <article className="d-xl-block d-none bg-gris">
                <SidebarReact visible={navVisible} show={showNavbar} />
              </article>
              <ScrollToTop />
              <Routes>
                <Route
                  path="/aliados/inicio"
                  element={
                    <section
                      className={!navVisible ? "page-with-navbar" : "page "}
                    >
                      <div
                        className={
                          darkMode
                            ? " container-dark "
                            : "container-light bg-gris"
                        }
                      >
                        <Inicio califico={califico} setCalifico={setCalifico} />
                      </div>
                    </section>
                  }
                />
                <Route
                  path="/aliados/contabilidad"
                  element={
                    <section
                      className={!navVisible ? "page-with-navbar " : "page  "}
                    >
                      <div
                        className={
                          darkMode
                            ? " container-dark "
                            : "container-light bg-gris"
                        }
                      >
                        <Contabilidad />
                      </div>
                    </section>
                  }
                />
                <Route
                  path="/aliados/analisis"
                  element={
                    <section
                      className={!navVisible ? "page-with-navbar " : "page  "}
                    >
                      <div
                        className={
                          darkMode
                            ? " container-dark "
                            : "container-light bg-gris"
                        }
                      >
                        <Analisis />
                      </div>
                    </section>
                  }
                />
                <Route
                  path="/aliados/cupones"
                  element={
                    <section
                      className={!navVisible ? "page-with-navbar " : "page  "}
                    >
                      <div
                        className={
                          darkMode
                            ? " container-dark "
                            : "container-light bg-gris"
                        }
                      >
                        <Tickets />
                      </div>
                    </section>
                  }
                />
                <Route
                  path="/aliados/calculadora"
                  element={
                    <section
                      className={!navVisible ? "page-with-navbar " : "page  "}
                    >
                      <div
                        className={
                          darkMode
                            ? " container-dark "
                            : "container-light bg-gris"
                        }
                      >
                        <Calculadora />
                      </div>
                    </section>
                  }
                />
                <Route
                  path="/aliados/calificar"
                  element={
                    <section
                      className={!navVisible ? "page-with-navbar " : "page  "}
                    >
                      <div
                        className={
                          darkMode
                            ? " container-dark "
                            : "container-light bg-gris"
                        }
                      >
                        <Calificar />
                      </div>
                    </section>
                  }
                />
              </Routes>
            </div>
          )}
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
