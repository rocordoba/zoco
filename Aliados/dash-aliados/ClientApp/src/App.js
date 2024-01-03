import React, { useContext, useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import "./custom.css";
import { DarkModeContext } from "./context/DarkModeContext";
import Inicio from "./views/Inicio";
import Contabilidad from "./views/Contabilidad";
import Analisis from "./views/Analisis";
import Tickets from "./views/Tickets";
import Calculadora from "./views/Calculadora";
import Calificar from "./views/Calificar";
import Login from "./views/Login";
import SidebarReact from "./components/SidebarReact";
import ScrollToTop from "./components/ScrollToTop";
import NuevoNavReact from "./components/NuevoNavReact";

function App() {
  const { darkMode } = useContext(DarkModeContext);
  const [navVisible, showNavbar] = useState(false);
  const [califico, setCalifico] = useState(0);
  // const [datosBack, setDatosBack] = useState({});
  // const [recuperar, setRecuperar] = useState(false);
  // const [showPassword, setShowPassword] = useState(false);
  const [usuario, setUsuario] = useState("");
  const [password, setPassword] = useState("");
  const [isActive, setIsActive] = useState(0);

  const [contador, setContador] = useState(0);
  const [datosMandados, setDatosMandados] = useState();

  const onSubmit = () => {
    console.log("Usuario:", usuario);
    console.log("Contraseña:", password);

    fetch("/api/acceso/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        UsuarioCuit: usuario,
        Clave: password,
      }),
    })
      // Procesar la respuesta de la API
      .then((response) => response.json())

      .then((data) => {
        // Verificar si el inicio de sesión fue exitoso o no
        setDatosMandados(data);
        console.log(data);
        if (data.IdUsuario !== 0) {
          alert("Inicio de sesión exitoso");
          setIsActive(1);

          window.location.reload();

          if (data.califico === 0 || data.califico === null) {
            console.log("aqui va el popup");
          }
        } else {
          alert("Revisar usuario/contraseña");
          setContador(contador + 1);
        }
      })
      .catch((error) => {
        console.error(error);
      });
  };

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
                onSubmit={onSubmit}
                datosMandados={datosMandados}
                setDatosMandados={setDatosMandados}
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
