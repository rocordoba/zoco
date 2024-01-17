import React, { useContext, useEffect, useState } from "react";
import { BrowserRouter, Routes, Route, useNavigate } from "react-router-dom";
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
import Home from "./views/landing/Home";

function App() {
  
    const { darkMode } = useContext(DarkModeContext);
    const [navVisible, showNavbar] = useState(false);
    const { califico, setCalifico, errorSesion } = useContext(DatosInicioContext);
    const { datosBackContext, codigoRespuesta } = useContext(DatosInicioContext);


  const showNavComponents =
    window.location.pathname !== "/" && window.location.pathname !== "/login";


 
    


  return (
    <div className={darkMode ? "container-dark" : "container-light bg-gris"}>
      <BrowserRouter>
        <div className="App">
          {showNavComponents && (
            <div>
              <div className="d-xl-none d-block my-3 ">
                <NuevoNavReact />
              </div>
              <article className="d-xl-block d-none bg-gris">
                <SidebarReact visible={navVisible} show={showNavbar} />
              </article>
            </div>
          )}
          <ScrollToTop />
          <Routes>
            <Route
              path="/"
              element={<Home showNavComponents={showNavComponents} />}
            />
            <Route
              path="/aliados/inicio"
              element={
                <section className={!navVisible ? "page-with-navbar" : "page "}>
                  <div
                    className={
                      darkMode ? " container-dark " : "container-light bg-gris"
                    }
                  >
                    <Inicio
                      showNavComponents={showNavComponents}
                      califico={califico}
                      setCalifico={setCalifico}
                    />
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
                      darkMode ? " container-dark " : "container-light bg-gris"
                    }
                  >
                    <Contabilidad showNavComponents={showNavComponents} />
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
                      darkMode ? " container-dark " : "container-light bg-gris"
                    }
                  >
                    <Analisis showNavComponents={showNavComponents} />
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
                      darkMode ? " container-dark " : "container-light bg-gris"
                    }
                  >
                    <Tickets showNavComponents={showNavComponents} />
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
                      darkMode ? " container-dark " : "container-light bg-gris"
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
                      darkMode ? " container-dark " : "container-light bg-gris"
                    }
                  >
                    <Calificar showNavComponents={showNavComponents} />
                  </div>
                </section>
              }
            />
            <Route
              path="/login"
              element={<Login showNavComponents={showNavComponents} />}
            />
          </Routes>
        </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
