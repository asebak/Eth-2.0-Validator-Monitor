using System;

namespace eth2validatormonitor.Integration
{
    public class Format
    {

        public static int SlotsPerEpoch => 32;

        public static int SecondsPerSlot => 12;

        public static long GenesisTimestamp => 1606824000;

        public static ValidatorStatus FormatValidatorStatus(string status)
        {
            //todo make complex object here
            if (status == "deposited" || status == "deposited_valid" || status == "deposited_invalid")
            {
                return ValidatorStatus.Deposited;
            }

            if (status == "pending") {
                return ValidatorStatus.Pending;
            }

            if (status == "active_online")
            {
                return ValidatorStatus.ActiveOnline;
            }

            if (status == "active_offline") {
                return ValidatorStatus.ActiveOffline;
            }

            if (status == "exiting_online")
            {
                return ValidatorStatus.ExitingOnline;
            }

            if (status == "exiting_offline")
            {
                return ValidatorStatus.ExitingOffline;
            }

            if (status == "slashing_online")
            {
                return ValidatorStatus.SlashingOnline;
            }

            if (status == "slashing_offline" )
            {
                return ValidatorStatus.SlashingOffline;
            }

            if (status == "exited")
            {
                return ValidatorStatus.Exited;
            }

            if (status == "slashed")
            {
                return ValidatorStatus.Slashed;
            }

            return ValidatorStatus.Unknown;

        }

        public static double FormatBalance(long balance)
        {
            return balance / Math.Pow(10, 9);
        }

        public static double FormatIncome(long income)
        {
            return Math.Round(FormatBalance(income), 4);
        }

        public static DateTime EpochToTime(int epoch)
        {
            var unixTimeStamp = GenesisTimestamp + epoch * SecondsPerSlot * SlotsPerEpoch;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
