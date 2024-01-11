import React, { useState } from "react";
import { Form, Button, Spinner } from "react-bootstrap";
import { useForm } from "react-hook-form";

import "./ContenidoLogin.css";
import {
  faEye,
  faEyeSlash,
  faUser,
  faLock,
  faCaretLeft,
  faEnvelope,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useNavigate } from "react-router-dom";

const ContenidoLogin = ({ onSubmit, datosMandados, setDatosMandados }) => {
  const [recuperar, setRecuperar] = useState(false);
  const [showPassword, setShowPassword] = useState(false);
  const [usuario, setUsuario] = useState("");
  const [password, setPassword] = useState("");
  const [isActive, setIsActive] = useState(0);
  const [isLoading, setIsLoading] = useState(false);
  const [buttonText, setButtonText] = useState("Conectar");
  const navigate = useNavigate();
  const [contador, setContador] = useState(0);

  const {
    reset,
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const handleMouseDown = (event) => {
    event.preventDefault();
    setShowPassword(!showPassword);
  };

  const handleLimpiarFormulario = () => {
    reset();
  };

  const onSubmit2 = () => {
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
      .then((response) => response.json())
      .then((data) => {
        setDatosMandados(data);
        console.log(data);
        if (data.token) {
          setIsActive(1);
          navigate("/aliados/inicio");
          // Almacenar el token y el ID del usuario en localStorage
          localStorage.setItem("token", data.token);
          localStorage.setItem("userId", data.userId);

          // Almacenar el token y el ID del usuario en sessionStorage
          sessionStorage.setItem("token", data.token);
          sessionStorage.setItem("userId", data.userId);
        } else {
          alert("Revisar usuario/contraseña");
          setButtonText("Conectar"); // Restablecer el texto del botón
          setIsLoading(false); // Det
          setContador(contador + 1);
        }
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return (
    <div>
      <div>
        {recuperar ? (
          // RECUPERAR PASSWORD
          <div className="bg-login py-5">
            <div className=" pb-3 text-center ">
              <h6 className="lato-bold fs-24 mb-3">Recuperar contraseña</h6>
              <h6 className="lato-regular fs-16 text-center mb-0">
                Ingresá tu email y te enviaremos un <br /> correo para
                cambiar tu contraseña
              </h6>
            </div>
            <div>
              <Form onSubmit={handleSubmit(onSubmit2)}>
                <article className="d-flex justify-content-center ">
                  <div>
                    <div className="d-flex  justify-content-center align-items-center input-formulario-user ">
                      <div>
                        <Form.Text>
                          <FontAwesomeIcon
                            className="fs-18"
                            icon={faEnvelope}
                          />
                        </Form.Text>
                      </div>
                      <div>
                        <Form.Group
                          className="d-flex justify-content-center "
                          controlId="formBasicEmail"
                        >
                          <Form.Control
                            className="border-0 input-transparente"
                            type="email"
                            placeholder="Email"
                            {...register("email", {
                              required: "El email es un dato obligatorio",
                              pattern: {
                                value:
                                  /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/,
                                message:
                                  "El email debe cumplir con un formato valido como el siguiente mail@mail.com ",
                              },
                            })}
                          />
                        </Form.Group>
                      </div>
                      <div className="ocultar-div">
                        <Button
                          className="border-0 "
                          onMouseDown={handleMouseDown}
                          variant="link"
                        >
                          {showPassword ? (
                            <FontAwesomeIcon icon={faEye} />
                          ) : (
                            <FontAwesomeIcon icon={faEyeSlash} />
                          )}
                        </Button>
                      </div>
                    </div>
                  </div>
                </article>
                <Form.Text className="text-danger d-flex justify-content-center">
                  {errors.email?.message}
                </Form.Text>
                <div className="d-flex justify-content-center">
                  <Button
                    className="my-3 btn-login lato-bold border-0"
                    type="submit"
                  >
                    Enviar
                  </Button>
                </div>
              </Form>
            </div>
            <div className="text-center d-md-block d-none">
              <div className="d-flex justify-content-center">
                <h6 className="fs-16 mb-0">
                  {" "}
                  ¿Olvidaste tu correo electrónico?{" "}
                </h6>
              </div>
              <div>
                <h6>
                  <a
                    className="enlace lato-bold text-decoration-none fs-16"
                    href="https://api.whatsapp.com/send/?phone=543813545650&text=Buenos%2Fas+d%C3%ADas%2Ftardes%2Cmi+CUIT+es%3A++tengo+una+consulta+sobre&type=phone_number&app_absent=0"
                    target="_blank"
                    rel="noreferrer"
                  >
                    Tocá aquí para contactarnos.
                  </a>
                </h6>
                <div className="d-flex justify-content-center">
                  <button
                    className="regresar border-0 "
                    onClick={() => setRecuperar(!recuperar)}
                  >
                    <FontAwesomeIcon className="me-1" icon={faCaretLeft} />
                    Regresar
                  </button>
                </div>
              </div>
            </div>
            <div className="text-center d-block d-md-none">
              <div className="d-flex  justify-content-center">
                <h6 className="fs-16 mb-0">
                  {" "}
                  ¿Olvidaste tu correo electrónico?{" "}
                </h6>
              </div>
              <div>
                <h6>
                  <a
                    className="enlace lato-bold fs-16 text-decoration-none"
                    href="https://api.whatsapp.com/send/?phone=543813545650&text=Buenos%2Fas+d%C3%ADas%2Ftardes%2Cmi+CUIT+es%3A++tengo+una+consulta+sobre&type=phone_number&app_absent=0"
                    target="_blank"
                    rel="noreferrer"
                  >
                    Tocá aquí para contactarnos.
                  </a>
                </h6>
                <div className="d-flex justify-content-center">
                  <button
                    className="regresar border-0 "
                    onClick={() => setRecuperar(!recuperar)}
                  >
                    <FontAwesomeIcon className="me-1" icon={faCaretLeft} />
                    Regresar
                  </button>
                </div>
              </div>
            </div>
          </div>
        ) : (
          // LOGIN
          <div className="bg-login  s py-5">
            <div className=" pb-3 text-center ">
              <h6 className="lato-bold fs-24 ">Inicio de sesión</h6>
            </div>
            <div>
              <Form onSubmit={handleSubmit(onSubmit2)}>
                <article className="d-flex justify-content-center my-3">
                  <div>
                    <div className="d-flex  justify-content-center align-items-center input-formulario-user ">
                      <div>
                        <Form.Text>
                          <FontAwesomeIcon className="fs-18" icon={faUser} />
                        </Form.Text>
                      </div>
                      <div>
                        <Form.Group
                          className="d-flex justify-content-center "
                          controlId="formBasicEmail"
                        >
                          <Form.Control
                            className="border-0 input-transparente"
                            type="text"
                            required
                            placeholder="Usuario"
                            value={usuario}
                            onChange={(e) => setUsuario(e.target.value)}
                          />
                        </Form.Group>
                      </div>
                      <div className="ocultar-div">
                        <Button
                          className="border-0 "
                          onMouseDown={handleMouseDown}
                          variant="link"
                        >
                          {showPassword ? (
                            <FontAwesomeIcon icon={faEye} />
                          ) : (
                            <FontAwesomeIcon icon={faEyeSlash} />
                          )}
                        </Button>
                      </div>
                    </div>
                  </div>
                </article>

                <article className="d-flex justify-content-center my-2">
                  <div>
                    <div className="d-flex  justify-content-center align-items-center input-formulario-user ">
                      <div>
                        <Form.Text className="">
                          <FontAwesomeIcon className="fs-18" icon={faLock} />
                        </Form.Text>
                      </div>
                      <div>
                        <Form.Group
                          className="d-flex justify-content-center "
                          controlId="formBasicPass"
                        >
                          <Form.Control
                            className=" border-0 input-transparente"
                            type={showPassword ? "text" : "password"}
                            required
                            placeholder="Contraseña"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                          />
                        </Form.Group>
                      </div>
                      <div>
                        <Button
                          className="border-0 "
                          onMouseDown={handleMouseDown}
                          variant="link"
                        >
                          {showPassword ? (
                            <FontAwesomeIcon icon={faEye} />
                          ) : (
                            <FontAwesomeIcon icon={faEyeSlash} />
                          )}
                        </Button>
                      </div>
                    </div>
                  </div>
                </article>
                <Form.Text className="text-danger d-flex justify-content-center">
                  {errors.password?.message}
                </Form.Text>
                <div className="d-flex justify-content-center">
                  <Button
                    disabled={contador === 4} // Deshabilitar si contador es 4
                    onClick={() => {
                      if (usuario && password) {
                        setIsLoading(true); // Cambiar al estado de carga si los campos no están vacíos
                        setButtonText("Conectar"); // Restablecer el texto del botón
                      } else {
                        // Realizar acciones si los campos están vacíos
                        // alert("Por favor, ingresa usuario y contraseña");
                      }
                    }}
                    className={
                      contador === 4
                        ? "my-4 btn-login-disabled lato-bold border-0"
                        : "my-4 btn-login lato-bold border-0"
                    }
                    type="submit"
                  >
                    {isLoading ? ( // Mostrar "Loading..." si isLoading es true, de lo contrario, el estado del botón
                      <>
                        Loading...
                        <Spinner
                          as="span"
                          animation="border"
                          size="sm"
                          role="status"
                          aria-hidden="true"
                        />
                      </>
                    ) : (
                      buttonText // Mostrar el texto del botón dinámicamente
                    )}
                  </Button>
                </div>
                {contador === 1 && (
                  <div className="d-flex justify-content-center text-center">
                    <h6 className="text-danger  fs-16-a-14 mx-5">
                      Te quedan 3 intentos más antes de restringir el acceso por
                      motivos de seguridad.
                    </h6>
                  </div>
                )}

                {contador === 2 && (
                  <div className="d-flex justify-content-center text-center">
                    <h6 className="text-danger  fs-16-a-14 mx-5">
                      Te quedan 2 intentos más antes de restringir el acceso por
                      motivos de seguridad.
                    </h6>
                  </div>
                )}

                {contador === 3 && (
                  <div className="d-flex justify-content-center text-center">
                    <h6 className="text-danger  fs-16-a-14 mx-5">
                      Te queda 1 intento más antes de restringir el acceso por
                      motivos de seguridad.
                    </h6>
                  </div>
                )}
                {contador === 4 && (
                  <div className="d-flex justify-content-center text-center">
                    <h6 className="text-danger  fs-16-a-14 mx-5">
                      LLegaste al límite de intentos posible. Te hemos
                      restringido el acceso por motivos de seguridad. Por favor
                      comunicate con el departamento de Liquidaciones para
                      resolver el problema.
                    </h6>
                  </div>
                )}
              </Form>
            </div>
            <div className="text-center d-md-block d-none">
              <div className="d-flex justify-content-center">
                <h6 className="fs-16 mb-1">
                  {" "}
                  ¿Problemas para ingresar?{" "}
                  <button
                    className="enlace border-0 lato-bold "
                    onClick={() => {
                      setRecuperar(!recuperar);
                      handleLimpiarFormulario();
                    }}
                  >
                    Tocá aquí.
                  </button>
                </h6>
              </div>
            </div>
            <div className="text-center d-block d-md-none">
              <div className="d-flex justify-content-center">
                <h6 className="fs-16 mb-1">
                  {" "}
                  ¿Problemas para ingresar?{" "}
                  <button
                    className="border-0 enlace lato-bold"
                    onClick={() => {
                      setRecuperar(!recuperar);
                      handleLimpiarFormulario();
                    }}
                  >
                    Tocá aquí.
                  </button>
                </h6>
              </div>
            </div>
          </div>
        )}
      </div>
    </div>
  );
};

export default ContenidoLogin;
