using System;

namespace _10Bridge1
{
    /// <summary>
    /// Az absztrakt osztályom a következőket tudja:
    /// 
    /// 1. Garantálja, hogy minden leszármaztatott osztálynak legyen Send() függvénye (ugyanúgy, mint a felületnél)
    /// 2. Garantálja, hogy minden leszármaztatott osztálynak legyen Setup() függvénye
    /// 3. Garantálja, hogy ezt a Setup() függvényt a konstruktor meghívja
    /// 4. Lehetővé teszi, hogy a leszármaztatott osztályok példányosítása ezen az egy helyen történjék.
    /// </summary>
    public abstract class AbstractSendWith
    {
        public AbstractSendWith()
        {
            //Mindig az adott leszármaztatás implementációjaát hívja
            Setup();
        }
        abstract protected void Setup();

        abstract public void Send(EmailMessage message);

        /// <summary>
        /// A protected miatt kívülről nem hívható a Setup, ez egy 
        /// saját, a hierarchián belülről hívható függvény csak,
        /// a példányosítás utáni setup céljából hívódik meg
        /// </summary>

        public static T Factory<T>()
            where T : AbstractSendWith, new()
        {
            //A felparaméterezés az adott implementáció dolga
            //ezért nem itt végezzük:
            //var tmp = new T();
            //tmp.Setup();

            //Mivel egy helyen példányosítunk, ezért
            //tudjuk paraméterezni a példányosítást
            //teszteléshez (Debug) egy felparaméterezett változat
            //éles (Release) futáshoz pedig a "rendes"
#if DEBUG
            if (typeof(T)==typeof(SendWithExchange))
            {
                return (T)(AbstractSendWith)((SendWithExchange)(new SendWithExchangeTest()));
            }
#endif

            return new T();
        }

        /// <summary>
        /// Legyen ez a B terv, se nem elegáns, se nem szép, de legalább nem generikus
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        //public static AbstractSendWith Factory(SendWithTypes type)
        //{
        //    switch (type)
        //    {
        //        case SendWithTypes.SendWith:
        //            //1. A felparaméterezés az adott implementáció dolga
        //            //2. innen is hívhatjuk a setupot, de a konstruktorból
        //            //   már központosítva van, az talán elegánsabb
        //            //var tmp = new SendWith();
        //            //tmp.Setup();

        //            return new SendWith();
        //        case SendWithTypes.SendWithExchange:
        //            //ugyanaz, mint eggyel feljebb
        //            return new SendWithExchange();
        //        case SendWithTypes.SendWithSendGrid:
        //            //ugyanaz, mint eggyel feljebb
        //            return new SendWithSendGrid();
        //        case SendWithTypes.SendWithMandrill:
        //            //ugyanaz, mint eggyel feljebb
        //            return new SendWithMandrill();
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(type));
        //    }
        //}

    }

    //public enum SendWithTypes
    //{
    //    SendWith, SendWithExchange, SendWithSendGrid, SendWithMandrill
    //}
}