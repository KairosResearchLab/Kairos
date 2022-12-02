using System;

namespace DynamicModel
{
    public class StatefulRegion<TState, TInput, TOutput> : IDisposable
        where TState : class
    {
        Func<TState, TInput, Tuple<TState, TOutput>> update;
        TState state;

        public void Update(Func<TState> create, Func<TState, TInput, Tuple<TState, TOutput>> update)
        {
            if (this.state == null)
                this.state = create();
            this.update = update;
        }

        public TOutput Invoke(TInput input)
        {
            var (newState, output) = update(state, input);
            state = newState;
            return output;
        }

        public void Dispose()
        {
            if (state is IDisposable d)
                d.Dispose();
        }
    }
}
