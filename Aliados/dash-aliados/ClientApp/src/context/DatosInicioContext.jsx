import React, { createContext, useState, useEffect } from "react";

export const DatosInicioContext = createContext();

export const DatosInicioProvider = ({ children }) => {
  const [datosBackContext, setDatosBackContext] = useState({});
  const apiUrlInicio = process.env.REACT_APP_API_INICIO;
  const apiUrlContabilidad = process.env.REACT_APP_API_CONTABILIDAD;
  const apiUrlAnalisis = process.env.REACT_APP_API_ANALISIS;
  const apiUrlCupones = process.env.REACT_APP_API_CUPONES;

  const [datos, setDatos] = useState(null);
 

  // La función para modificar los datos del contexto
  const actualizarDatos = (nuevosDatos) => {
    setDatos(nuevosDatos);
  };

  useEffect(() => {
    const token = sessionStorage.getItem("token");

    if (token) {
      const currentDate = new Date();
      const year = datos?.anio || currentDate.getFullYear();
      const month = datos?.mes || currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
      const week = datos?.semana || Math.ceil(currentDate.getDate() / 7);
      const comercio = datos?.comercio || "Todos";
      const day = currentDate.getDay();

      const requestData = {
        //    token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIzMzMzMzMzMzMzMyIsIm5iZiI6MTcwNTA2Mzg4NCwiZXhwIjoxNzA1MDYzOTQ0LCJpYXQiOjE3MDUwNjM4ODR9.aKMFYoueJqJJhrMzErDTqgVNEs30d3sn9P6etmgpbAs",
        token: token,
        year: year,
        month: month,
        week: week,
        comercio: comercio,
        day: day,
      };

      fetch(apiUrlInicio, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestData),
      })
        .then((response) => {
          if (response.status === 200) {
            return response.json();
          } else if (response.status === 401) {
            // Aqu� puedes manejar la l�gica para el estado 401
            console.error("Usuario no autorizado");
          } else {
            throw new Error("Error en la solicitud");
          }
        })
        .then((data) => {
          setDatosBackContext(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, [datos]);

  const [datosMandados, setDatosMandados] = useState();
  const [datosContabilidadContext, setDatosContabilidadContext] = useState({});
  useEffect(() => {
    const token = sessionStorage.getItem("token");

    const currentDate = new Date();
    const year = datos?.anio || currentDate.getFullYear();
    const month = datos?.mes || currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = datos?.semana || Math.ceil(currentDate.getDate() / 7);
    const comercio = datos?.comercio || "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,
      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };

    if (token) {
      fetch(apiUrlContabilidad, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestData),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("");
          }
          return response.json();
        })
        .then((data) => {
          setDatosContabilidadContext(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, [datos]);

  const [datosAnalisisContext, setDatosAnalisisContext] = useState({});
  useEffect(() => {
    const token = sessionStorage.getItem("token");
    const currentDate = new Date();
    const year = datos?.anio || currentDate.getFullYear();
    const month = datos?.mes || currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = datos?.semana || Math.ceil(currentDate.getDate() / 7);
    const comercio = datos?.comercio || "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,
      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };
    if (token) {
      fetch(apiUrlAnalisis, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestData),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("");
          }
          return response.json();
        })
        .then((data) => {
          setDatosAnalisisContext(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, [datos]);

  const [datosCuponesContext, setDatosCuponesContext] = useState({});

  useEffect(() => {
    const token = sessionStorage.getItem("token");
    const currentDate = new Date();
    const year = datos?.anio || currentDate.getFullYear();
    const month = datos?.mes || currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = datos?.semana || Math.ceil(currentDate.getDate() / 7);
    const comercio = datos?.comercio || "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,

      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };

    if (token) {
      fetch(apiUrlCupones, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestData),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("");
          }
          return response.json();
        })
        .then((data) => {
          setDatosCuponesContext(data);
        })
        .catch((error) => {
          console.error("Error en la solicitud:", error);
        });
    }
  }, [datos]);

  return (
    <DatosInicioContext.Provider
      value={{
        datos,
        actualizarDatos,
        datosBackContext,
        setDatosBackContext,
        datosCuponesContext,
        datosMandados,
        setDatosMandados,
        datosContabilidadContext,
        setDatosContabilidadContext,
        datosAnalisisContext,
        setDatosAnalisisContext,
      }}
    >
      {children}
    </DatosInicioContext.Provider>
  );
};
