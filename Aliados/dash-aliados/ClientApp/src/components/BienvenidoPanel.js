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
                      setSelectedAnio({ ...selectedOption, value: Number(selectedOption.value) });
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
                      actualizarSemanasPorMes(selectedAnio.value, selectedOption.value);
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
    </section>
  );
};

export default BienvenidoPanel;
