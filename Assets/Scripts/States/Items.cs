namespace Items
{
    public interface IState
    {
        void OnActive();
    }



    public class StateMachine
    {
        public IState ItemState { get; private set; }

        public StateMachine() { }

        public StateMachine(IState itemState)
        {
            ActiveState(itemState);
        }

       
        public void ActiveState(IState itemState)
        {
            ItemState = itemState;

            ItemState.OnActive();
        }

        public StateType GetCurrentStateAsType<StateType>() where StateType : class, IState
        {
            return ItemState as StateType;
        }
    }


}


