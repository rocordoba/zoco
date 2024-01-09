import React, { createContext, useState, useEffect } from 'react';

export const DatosInicioContext = createContext();

export const DatosInicioProvider = ({ children }) => {
  const [datosBackContext, setDatosBackContext] = useState({});

  useEffect(() => {
    const token = localStorage.getItem('token');
    const userId = localStorage.getItem('userId');
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
      fetch('/api/datosinicio/base', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(requestData),
      })
        .then(response => {
          if (!response.ok) {
            throw new Error('Error en la solicitud');
          }
          return response.json();
        })
        .then(data => {
          setDatosBackContext(data);
        })
        .catch(error => {
          console.error('Error en la solicitud:', error);
        });
    }
  }, []);


  const [datosCuponesContext, setDatosCuponesContext]= useState({})

   useEffect(() => {
        const token = localStorage.getItem("token");
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
                    console.log("Datos recuperados:", data);
                    setDatosCuponesContext(data);
                })
                .catch((error) => {
                    console.error("Error en la solicitud:", error);
                });
        }
    }, []);
    

    const [califico, setCalifico] = useState(0);
    const [isActive, setIsActive] = useState(0);
    const [usuario, setUsuario] = useState("");
    const [password, setPassword] = useState("");
  
    const [contador, setContador] = useState(0);
    const [datosMandados, setDatosMandados] = useState();
  
    const [datosContabilidadContext, setDatosContabilidadContext] = useState({});
    useEffect(() => {
      const token = localStorage.getItem("token");
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

  return (
    <DatosInicioContext.Provider 
    value={{ 
      datosBackContext, 
      setDatosBackContext,
      datosCuponesContext,
      datosMandados,
      setDatosMandados,
      datosContabilidadContext, 
      setDatosContabilidadContext
      }}>
      {children}
    </DatosInicioContext.Provider>
  );
};

