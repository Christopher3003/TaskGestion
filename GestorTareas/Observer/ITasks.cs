namespace ProbarApp.Observer
{
    public interface ITasks
    {
        void Attash(Usuarios observer);
        void Detash(Usuarios observer);
        void Notify();
    }
}
