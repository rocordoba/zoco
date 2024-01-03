import React, { createContext, useState, useEffect } from 'react';

export const DatosInicioContext = createContext();

export const DatosInicioProvider = ({ children }) => {
  const [datosBackContext, setDatosBackContext] = useState({});

  useEffect(() => {
    const token = localStorage.getItem('token');
    const userId = localStorage.getItem('userId');
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = currentDate.getMonth() + 1; 
    const week = Math.ceil(currentDate.getDate() / 7); 
    const comercio = 'Todos';
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

  return (
    <DatosInicioContext.Provider value={{ datosBackContext, setDatosBackContext }}>
      {children}
    </DatosInicioContext.Provider>
  );
};

