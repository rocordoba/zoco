import React from "react";
import video from "../../assets/img/video.mp4";
import logoNav from "../../assets/img/logo.png";

const HeroVideo = () => {
  return (
    <div data-bs-theme="dark">
      <article className="navbar navbar-expand-lg navbar-light fixed-top bg-light">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
            <img
              className="Zoco-Servicio-Pago"
              src={logoNav}
              alt="Zoco-Servicio de pagos"
            />
          </a>

          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarCollapse"
            aria-controls="navbarCollapse"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span
              className="navbar-toggler-icon"
              style={{
                "--bs-navbar-toggler-icon-bg":
                  'url(\'data:image/svg+xml,%3csvg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 30 30"%3e%3cpath stroke="rgba(0, 0, 0, 0.29)" stroke-linecap="round" stroke-miterlimit="10" stroke-width="2" d="M4 7h22M4 15h22M4 23h22"/%3e%3c/svg%3e\')',
              }}
            ></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarCollapse">
            <ul className="navbar-nav me-auto mb-2 mb-md-0">
              <li className="navbar-item">
                <a className="nav-link" aria-current="page" href="#home">
                  Home
                </a>
              </li>
              <li className="navbar-item">
                <a className="nav-link" href="#porque">
                  ¿Por qué Zoco?
                </a>
              </li>
              <li className="navbar-item">
                <a className="nav-link" href="#hardware">
                  Hardware
                </a>
              </li>
              <li className="navbar-item">
                <a className="nav-link" href="#precios">
                  Precios
                </a>
              </li>
              <li className="navbar-item">
                <a className="nav-link" href="#seccion-preguntas">
                  Preguntas frecuentes
                </a>
              </li>
            </ul>
            <form className="d-flex" role="search" id="btnIniciarSesion">
              <div className="navbar-btn">
                <a className="btn main-btn" href="../app_zoco/home/index.php">
                  Iniciar sesión
                </a>
              </div>
            </form>
          </div>
        </div>
      </article>
      <header data-bs-theme="dark">
        <div className="page-hero">
          <div className="content-video">
            <video
              className="object-fit-contain"
              loop
              autoPlay
              playsInline
              muted
              src={video}
              type="video/mp4"
            ></video>
          </div>

          <div className="container">
            <div className="hero-text text-start">
              <h1 id="hero-title">
                <span className="colorz">Preciso. Sencillo. Seguro.</span>
              </h1>
              <p className="colorw" id="hero-p">
                Somos una plataforma de servicios de pago diseñada para
                simplificar y optimizar tus operaciones financieras. Trabajamos
                para proporcionarte las herramientas y el asesoramiento que
                necesitas para crecer y prosperar en un mundo empresarial en
                constante cambio.
              </p>
            </div>
          </div>
        </div>
      </header>
    </div>
  );
};

export default HeroVideo;
