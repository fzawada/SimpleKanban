namespace SimpleKanban.Domain
{
    public abstract class Event
    {
        public override bool Equals(object obj)
        {
            var props = GetType().GetProperties();

            foreach (var prop in props)
            {
                var thisVal = prop.GetValue(this);
                var otherVal = prop.GetValue(obj);
                if (!thisVal.Equals(otherVal))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 0;
            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                hashCode = hashCode ^ prop.GetValue(this).GetHashCode();
            }

            return hashCode;
        }
    }
}
