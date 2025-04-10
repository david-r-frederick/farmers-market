"use client";

import { Link } from "@remix-run/react";
import { useState } from "react";
import { Button } from "../common/Button";
// eslint-disable-next-line import/no-unresolved
import { useApi } from "~/api/useApi";

export default function Header(): JSX.Element {
  const [ isOpen, setIsOpen ] = useState(false);

  const api = useApi();

  const testConnection = async () => {
    try {
      const response = await api.starting_TestConnection();
      console.log("Connection successful:", response);
    } catch (error) {
      console.error("Connection failed:", error);
    }
  };

  return (
    <header className="bg-primary text-white">
      <div className="max-w-7xl mx-auto px-4 py-4 flex justify-between items-center">
        <Link to="/" className="text-xl font-bold">
          My Website
        </Link>
        <div className="md:hidden">
          <button
            onClick={() => setIsOpen(!isOpen)}
            type="button"
            className="text-gray-200 focus:outline-none"
          >
            <svg
              className="w-6 h-6"
              fill="none"
              stroke="currentColor"
              viewBox="0 0 24 24"
              xmlns="http://www.w3.org/2000/svg"
            >
              {isOpen ? (
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M6 18L18 6M6 6l12 12"
                />
              ) : (
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M4 6h16M4 12h16m-7 6h7"
                />
              )}
            </svg>
          </button>
        </div>
        <nav className="hidden md:flex space-x-4">
          <Button
            type="button"
            onClick={() => testConnection()}
          >
            Test API
          </Button>
          <Link to="/vendor-registration" className="hover:text-gray-300">
            Vendor Registration
          </Link>
          <Link to="/contact-us" className="hover:text-gray-300">
            Contact Us
          </Link>
          <Link to="/faq" className="hover:text-gray-300">
            FAQ
          </Link>
        </nav>
      </div>

      {/* Mobile Menu */}
      {isOpen && (
        <nav className="md:hidden bg-gray-700">
          <div className="flex flex-col space-y-2 p-4">
            <Link
              to="/vendor-registration"
              className="hover:text-gray-300"
              onClick={() => setIsOpen(false)}
            >
              Vendor Registration
            </Link>
            <Link
              to="/contact-us"
              className="hover:text-gray-300"
              onClick={() => setIsOpen(false)}
            >
              Contact Us
            </Link>
            <Link
              to="/faq"
              className="hover:text-gray-300"
              onClick={() => setIsOpen(false)}
            >
              FAQ
            </Link>
          </div>
        </nav>
      )}
    </header>
  );
}
