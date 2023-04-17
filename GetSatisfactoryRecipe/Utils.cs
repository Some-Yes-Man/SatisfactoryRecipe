namespace GetSatisfactoryRecipe {
    public class Utils {
        public static Guid XorGuids(Guid guidOne, Guid guidTwo) {
            byte[] bytesOne = guidOne.ToByteArray();
            byte[] bytesTwo = guidTwo.ToByteArray();
            return new Guid(new byte[16] { (byte)(bytesOne[0] ^ bytesTwo[0]), (byte)(bytesOne[1] ^ bytesTwo[1]), (byte)(bytesOne[2] ^ bytesTwo[2]), (byte)(bytesOne[3] ^ bytesTwo[3]),
                (byte)(bytesOne[4] ^ bytesTwo[4]), (byte)(bytesOne[5] ^ bytesTwo[5]), (byte)(bytesOne[6] ^ bytesTwo[6]), (byte)(bytesOne[7] ^ bytesTwo[7]),
                (byte)(bytesOne[8] ^ bytesTwo[8]), (byte)(bytesOne[9] ^ bytesTwo[9]), (byte)(bytesOne[10] ^ bytesTwo[10]), (byte)(bytesOne[11] ^ bytesTwo[11]),
                (byte)(bytesOne[12] ^ bytesTwo[12]), (byte)(bytesOne[13] ^ bytesTwo[13]), (byte)(bytesOne[14] ^ bytesTwo[14]), (byte)(bytesOne[15] ^ bytesTwo[15]) });
        }

        public static Guid XorGuids(IEnumerable<Guid> ids) {
            Guid mergedId = Guid.Empty;
            foreach (var id in ids) {
                mergedId = XorGuids(mergedId, id);
            }
            return mergedId;
        }
    }
}
