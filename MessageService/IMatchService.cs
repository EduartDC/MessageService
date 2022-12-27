﻿
using MessageService.Domain;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{

    [ServiceContract(CallbackContract = typeof(IMatchServiceCallBack), SessionMode = SessionMode.Required)]
    internal interface IMatchService
    {
        [OperationContract(IsOneWay = true)]
        void StartLobby(string username, string code);

        [OperationContract(IsOneWay = true)]
        void AddToLobby(string username, string code);

        [OperationContract(IsOneWay = true)]
        void StartMatch(MatchServer newMatch);

        [OperationContract(IsOneWay = true)]
        void DisconnectFromLobby(PlayerServer player, string code);

        [OperationContract(IsOneWay = true)]
        void DisconnectFromMatch(PlayerServer player);

        [OperationContract(IsOneWay = true)]
        void SetCallbackMatch(string username);

        [OperationContract]
        List<QuestionServer> GetQuestions();

        [OperationContract]
        List<AnswerServer> GetAnswers(QuestionServer question);

        [OperationContract]
        int addPoints(PlayerServer player, int score);

        [OperationContract]
        void UpdateBoard();

        [OperationContract]
        void UpdateStrikes();

    }

    [ServiceContract]
    public interface IMatchServiceCallBack
    {

        [OperationContract(IsOneWay = true)]
        void UpdateLobby(List<PlayerServer> plyers);

        [OperationContract(IsOneWay = true)]
        void LoadMatch(MatchServer match);
    }
}
