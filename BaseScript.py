import clr
from abc import ABCMeta, abstractmethod
clr.AddReference("TestIronPython")


from TestIronPython import AuthorizationStatus, PolicyCheckResult


class Result(object):
    __metaclass__ = ABCMeta

    @abstractmethod
    def get_result(self):
        """
        Get the result of this authorization operation
        :return : A PolicyCheckResult from our API
        """
        pass
