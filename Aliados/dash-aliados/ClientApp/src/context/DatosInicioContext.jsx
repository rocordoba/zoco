import React, { createContext, useState, useEffect } from "react";

export const DatosInicioContext = createContext();

export const DatosInicioProvider = ({ children }) => {
  const [datosBackContext, setDatosBackContext] = useState({});

    useEffect(() => {
        const token = sessionStorage.getItem("token");

        if (token) {
            const currentDate = new Date();
            const year = currentDate.getFullYear();
            const month = currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
            const week = Math.ceil(currentDate.getDate() / 7);
            const comercio = "Todos";
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

            fetch("/api/datosinicio/base", {
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
                        // Aquí puedes manejar la lógica para el estado 401
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
    }, []);


  const [datosCuponesContext, setDatosCuponesContext] = useState({});

  useEffect(() => {
      const token = sessionStorage.getItem("token");
    const userId = localStorage.getItem("userId");
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = Math.ceil(currentDate.getDate() / 7); // Obtener la semana actual
    const comercio = "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,
      id: userId,
      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };

    if (token && userId) {
      fetch(`/api/cupones/cupones`, {
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
  }, []);

  const [datosMandados, setDatosMandados] = useState();
  const [datosContabilidadContext, setDatosContabilidadContext] = useState({});
  useEffect(() => {
      const token = sessionStorage.getItem("token");
    const userId = localStorage.getItem("userId");

    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = Math.ceil(currentDate.getDate() / 7); // Obtener la semana actual
    const comercio = "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,
      id: userId,
      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };

    if (token && userId) {
      fetch(`/api/contablidad/contabilidad`, {
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
  }, []);

  const [datosAnalisisContext, setDatosAnalisisContext] = useState({});
  useEffect(() => {
      const token = sessionStorage.getItem("token");
    const userId = localStorage.getItem("userId");
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth() + 1; // Sumar 1 porque los meses van de 0 a 11
    const week = Math.ceil(currentDate.getDate() / 7); // Obtener la semana actual
    const comercio = "Todos";
    const day = currentDate.getDay();
    const requestData = {
      token: token,
      id: userId,
      year: year,
      month: month,
      week: week,
      comercio: comercio,
      day: day,
    };
    if (token && userId) {
      fetch(`/api/analisis/analisis`, {
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
  }, []);

  return (
    <DatosInicioContext.Provider
      value={{
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
