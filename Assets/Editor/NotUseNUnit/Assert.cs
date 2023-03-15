namespace Editor.NotUseNUnit
{
    public static class Assert
    {
        public static void AreEqual(int expected, int actual)
        {
            if (expected != actual)
            {
                throw new System.Exception($"Assert.AreEqual failed. Expected: {expected}, Actual: {actual}");
            }
        }
    }
}