﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTransitoMunicipal.pocos
{
    class Vehiculo
    {
        private String numeroLicencia;
        private int idVehiculo;
        private String marca;
        private String modelo;
        private String año;
        private String color;
        private String aseguradora;
        private String numeroPoliza;
        private String numeroPlacas;

        public string NumeroLicencia { get => numeroLicencia; set => numeroLicencia = value; }
        public int IdVehiculo { get => idVehiculo; set => idVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Año { get => año; set => año = value; }
        public string Color { get => color; set => color = value; }
        public string Aseguradora { get => aseguradora; set => aseguradora = value; }
        public string NumeroPoliza { get => numeroPoliza; set => numeroPoliza = value; }
        public string NumeroPlacas { get => numeroPlacas; set => numeroPlacas = value; }
    }
}