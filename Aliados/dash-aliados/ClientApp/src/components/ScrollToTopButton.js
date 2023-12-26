import { faCircleArrowUp } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";

const ScrollToTopButton = () => {
  const scrollToTop = () => {
    window.scrollTo(0, 0);
  };

  const buttonStyle = {
    position: "fixed",
    bottom: "20px",
    right: "20px",
    zIndex: 1000,
  };

  const iconSize = "2x"; 

  return (
    <div>
      <FontAwesomeIcon
        className="color-verde"
        onClick={scrollToTop}
        style={buttonStyle}
        icon={faCircleArrowUp}
        size={iconSize}
      />
    </div>
  );
};

export default ScrollToTopButton;
