using System.Collections;
using UnityEngine;

namespace ServerTools
{
    class ShutdownTimer
    {
        public static int PermLevelNeededforShutdown = 0;

        public static IEnumerator StartShutdownTimer(ClientInfo _cInfo)
        {
            if (!GameManager.Instance.adminTools.IsAdmin(_cInfo.playerId))
            {
                string _phrase200 = "{PlayerName} you do not have permissions to use this command.";
                if (Phrases.Dict.TryGetValue(200, out _phrase200))
                {
                    _phrase200 = _phrase200.Replace("{PlayerName}", _cInfo.playerName);
                }
                _cInfo.SendPackage(new NetPackageGameMessage(EnumGameMessages.Chat, string.Format("{0}{1}[-]", CustomCommands.ChatColor, _phrase200), "Server", false, "", false));
            }
            else
            {
                AdminToolsClientInfo _admin = GameManager.Instance.adminTools.GetAdminToolsClientInfo(_cInfo.playerId);
                if (_admin.PermissionLevel > PermLevelNeededforShutdown)
                {
                    string _phrase200 = "{PlayerName} your permission level is not high enough to use this command.";
                    _phrase200 = _phrase200.Replace("{PlayerName}", _cInfo.playerName);

                    _cInfo.SendPackage(new NetPackageGameMessage(EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF0000]", _phrase200), "Server", false, "", false));
                }
                else
                {
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 10 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 9 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 8 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 7 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 6 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 5 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 4 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 3 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 2 Minutes."), "Server", false, "", false);
                    yield return new WaitForSeconds(60);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 1 Minute."), "Server", false, "", false);
                    yield return new WaitForSeconds(30);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 30 Seconds."), "Server", false, "", false);
                    yield return new WaitForSeconds(20);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 10 Seconds."), "Server", false, "", false);
                    yield return new WaitForSeconds(5);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 5 Seconds."), "Server", false, "", false);
                    yield return new WaitForSeconds(1);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 4 Seconds."), "Server", false, "", false);
                    yield return new WaitForSeconds(1);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 3 Seconds."), "Server", false, "", false);
                    yield return new WaitForSeconds(1);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 2 Seconds."), "Server", false, "", false);
                    yield return new WaitForSeconds(1);
                    GameManager.Instance.GameMessageServer(_cInfo, EnumGameMessages.Chat, string.Format("{0}{1}[-]", "[FF8000]", "The server will be shutting down in 1 Second."), "Server", false, "", false);
                    yield return new WaitForSeconds(1);

                    Log.Out("[SERVERTOOLS] World Shutdown.");
                    SdtdConsole.Instance.ExecuteSync("shutdown", _cInfo);
                }
            }
        }
    }
}
