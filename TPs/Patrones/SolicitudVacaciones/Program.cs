using System;

// Clase para representar una solicitud de vacaciones
class SolicitudVacaciones
{
    public int Dias { get; set; }
    public SolicitudVacaciones(int dias)
    {
        Dias = dias;
    }
}

// Clase abstracta que define el Handler (manejador)
abstract class Supervisor
{
    // Almacenamos una referencia al siguiente supervisor
    protected Supervisor? SupervisorSiguiente;

    public void EstablecerSiguienteSupervisor(Supervisor supervisor)
    {
        SupervisorSiguiente = supervisor;
    }

    public abstract void ProcesarSolicitud(SolicitudVacaciones solicitud);
}

// Implementación concreta de Supervisor
class SupervisorJunior : Supervisor
{
    public override void ProcesarSolicitud(SolicitudVacaciones solicitud)
    {
        if (solicitud.Dias <= 5)
        {
            Console.WriteLine("Solicitud aprobada por el Supervisor Junior.");
        }
        else if (SupervisorSiguiente != null)
        {
            SupervisorSiguiente.ProcesarSolicitud(solicitud);
        }
        
    }
}

// Implementación concreta de Supervisor
class SupervisorSenior : Supervisor
{
    public override void ProcesarSolicitud(SolicitudVacaciones solicitud)
    {
        if (solicitud.Dias <= 10)
        {
            Console.WriteLine("Solicitud aprobada por el Supervisor Senior.");
        }
        else if (SupervisorSiguiente != null)
        {
            SupervisorSiguiente.ProcesarSolicitud(solicitud);
        }
        
    }
}

// Implementación concreta de Supervisor
class Gerente : Supervisor
{
    public override void ProcesarSolicitud(SolicitudVacaciones solicitud)
    {
        if (solicitud.Dias <= 15)
        {
            Console.WriteLine("Solicitud aprobada por el Gerente.");
        }
        else
        {
            Console.WriteLine("Nadie puede aprobar esta solicitud.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Configuración de la cadena de responsabilidad
        SupervisorJunior supervisorJunior = new SupervisorJunior();
        SupervisorSenior supervisorSenior = new SupervisorSenior();
        Gerente gerente = new Gerente();

        supervisorJunior.EstablecerSiguienteSupervisor(supervisorSenior);
        supervisorSenior.EstablecerSiguienteSupervisor(gerente);

        // Procesamiento de solicitudes
        SolicitudVacaciones solicitud1 = new SolicitudVacaciones(10);
        SolicitudVacaciones solicitud2 = new SolicitudVacaciones(12);
        SolicitudVacaciones solicitud3 = new SolicitudVacaciones(20);

        supervisorJunior.ProcesarSolicitud(solicitud1);
        // supervisorJunior.ProcesarSolicitud(solicitud2);
        // supervisorJunior.ProcesarSolicitud(solicitud3);
    }
}
