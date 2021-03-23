using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDocenteModel.Mappers
{
    public abstract class GeneralMapper<T1, T2>
    {
        public abstract T1 MapperT2T1(T2 input);
        public abstract T2 MapperT1T2(T1 input);
        public abstract IEnumerable<T1> MapperT2T1(IEnumerable<T2> input);
        public abstract IEnumerable<T2> MapperT1T2(IEnumerable<T1> input);
    }

    /*
    class Persona
    {
        // Plantilla que puede heredar de una sola clase
        // firma de métodos + implementación
    }

    abstract class PersonaAbstracta
    {
        // Puede tener métodos implementados o solo la firma de ellos
    }

    public interface IPersona
    {
        int sumar(int n1, int n2);


        // Solo poseo las firmas de los métodos y no su implementación, las clases
        // que implementan la interface serán las encargadas de agregar el comportamiento
        // a cada método
    }*/


}
