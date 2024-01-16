import React, { useContext, useEffect, useState } from "react";
import Select from "react-select";
import "./BienvenidoPanel.css";
import { DarkModeContext } from "../context/DarkModeContext";
import { DatosInicioContext } from "../context/DatosInicioContext";
import Swal from "sweetalert2";

const BienvenidoPanel = () => {
  const { darkMode } = useContext(DarkModeContext);
  const [datoCapturados, setDatoCapturados] = useState({});
  const [isSearchable, setIsSearchable] = useState(true);
  const [selectedMes, setSelectedMes] = useState(null);
  const [selectedComercio, setSelectedComercio] = useState(null);

  const { actualizarDatos } = useContext(DatosInicioContext);

  const [notificaciones, setNotificaciones] = useState({
    semanas: [],
  });

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
          setNotificaciones(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, []);

  const handleEnviarDatos = () => {
    const data = {
      anio: selectedAnio?.value,
      mes: selectedMes?.value,
      comercio: selectedComercio?.value,
      semana: selectedSemana?.value,
    };
    setDatoCapturados(data);
    actualizarDatos(data);
  };

  // const generarOpciones = () => {

  //   const opcionesMeses = notificaciones.meses.map(mes => ({
  //     value: mes,  // Asumiendo que 'mes' tiene un formato adecuado
  //     label: mes.toString()
  //   }));

  //   const opcionesSemanas = notificaciones.semanas.map(semana => ({
  //     value: semana,  // Asumiendo que 'semana' tiene un formato adecuado
  //     label: semana.toString()
  //   }));

  //   const opcionesComercios = notificaciones.comercios.map(comercio => ({
  //     value: comercio,
  //     label: comercio
  //   }));

  //   return { opcionesAnios, opcionesMeses, opcionesSemanas, opcionesComercios };
  // };
  const opcionesSemanas = notificaciones.semanas.flatMap(anio =>
    anio.meses.flatMap(mes =>
      mes.semanas.map(semanaObj => {
        const semanaNum = semanaObj.semana; // Accediendo al número de la semana
        return {
          value: semanaNum, // Usando el número de la semana como valor
          label: `Semana: ${semanaNum}` // Usando el número de la semana en la etiqueta
        };
      })
    )
  );
  

  const opcionesAnios = notificaciones.semanas.map((anio) => ({
    value: anio.año,
    label: anio.año.toString(),
  }));

  const [selectedAnio, setSelectedAnio] = useState(null);
  console.log("🚀 ~ BienvenidoPanel ~ selectedAnio:", selectedAnio);
  const [selectedSemana, setSelectedSemana] = useState(null);
  console.log("🚀 ~ BienvenidoPanel ~ selectedSemana:", selectedSemana);

  return (
    <section
      className={
        darkMode
          ? " contenedor-panel-control-dark py-4   container"
          : "py-4  contenedor-panel-control container"
      }
    >
      <div className="">
        <div className="row">
          <div className="col-md-2  my-3 ">
            <h6 className="text-center heavy-900 fs-16 ms-2">
              {" "}
              Bienvenido/a al <br />{" "}
              <span className="text-center heavy-900 color-verde fs-25 line-h-26">
                {" "}
                Panel de Control
              </span>{" "}
            </h6>
          </div>

          <div className="col-md-10 ">
            <div>
              <article className="borde-caja-panel"></article>
              <form className="d-flex justify-content-around">
                <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Año
                  </label>
                  <Select
                    value={selectedAnio}
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="anio"
                    options={opcionesAnios}
                    onChange={(selectedOption) =>
                      setSelectedAnio(selectedOption)
                    }
                  />
                </article>
                {/* <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Mes
                  </label>
                  <Select
                    value={selectedMes}
                    defaultInputValue={"Octubre"}
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="mes"
                    options={opcionesMeses}
                    onChange={(selectedOption) =>
                      setSelectedMes(selectedOption)
                    }
                    styles={{
                      control: (base) => ({
                        ...base,
                        textAlign: "center",
                      }),
                    }}
                  />
                </article> */}
                <article>
                  <label
                    htmlFor="exampleFormControlInput1"
                    className="lato-bold fs-16 ms-3"
                  >
                    Semanas
                  </label>
                  <Select
                    className="select__control_custom lato-bold"
                    classNamePrefix="select"
                    isSearchable={isSearchable}
                    name="semanas"
                    value={selectedSemana}
                    options={opcionesSemanas}
                    onChange={(selectedOption) =>
                      setSelectedSemana(selectedOption)
                    }
                    styles={{
                      control: (base) => ({
                        ...base,
                        textAlign: "center",
                      }),
                    }}
                  />
                </article>
                {/* <article>
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
                    options={opcionesComercios}
                    onChange={(selectedOption) =>
                      setSelectedComercio(selectedOption)
                    }
                    styles={{
                      control: (base) => ({
                        ...base,
                        textAlign: "center",
                      }),
                    }}
                  />
                </article> */}

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
    </section>
  );
};

export default BienvenidoPanel;
